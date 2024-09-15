using System.Collections.Generic;
using ComponentScripts;
using ComponentScripts.Entities;
using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Enemies;
using ComponentScripts.Entities.Nest;
using Services.BaseEntityServices;
using Services.CharacterServices.CharacterAttackScripts;
using Services.CharacterServices.CharacterStatsScripts;
using Services.CharacterServices.MovingScripts;
using Services.EnemyServices;
using UnityEngine;

namespace Injectors
{
    public class Injector : MonoBehaviour
    {
        [SerializeField] private CharacterMover character;
        [SerializeField] private List<EntitySpawnHandler> spawners;

        private void Awake()
        {
            InjectToSpawners();

            foreach (var spawner in spawners)
            {
                spawner.OnEntitySpawn += InjectToEntities;
            }
            
            
            IPlayerMover playerMover = gameObject.AddComponent<PlayerMoverService>();
            character.Inject(playerMover);
            
            IStaminaHandler staminaHandler = gameObject.AddComponent<StaminaHandlerService>();
            playerMover.Inject(staminaHandler);

            CharacterHealthHandler characterHealthHandler = character.gameObject.GetComponent<CharacterHealthHandler>();
            ICharacterHealthHandler characterHealthHandlerI = gameObject.AddComponent<CharacterHealthHandlerService>();
            
            ICharacterDamageReceiver characterDamageReceiver = new CharacterDamageReceiveService();
            characterHealthHandler.Inject(characterHealthHandlerI, characterDamageReceiver);
            characterDamageReceiver.Inject(characterHealthHandlerI);

            ICharacterAttackHandler characterAttackHandlerI = new CharacterAttackService();
            CharacterAttackHandler characterAttackHandler = character.GetComponent<CharacterAttackHandler>();
            characterAttackHandler.Inject(characterAttackHandlerI);
            
        }

        private void OnDestroy()
        {
            foreach (var spawner in spawners)
            {
                spawner.OnEntitySpawn -= InjectToEntities;
            }
        }

        private void InjectToSpawners()
        {
            ISpawner iSpawner = gameObject.AddComponent<SpawnerService>();
            foreach (var spawner in spawners)
            {
                if (spawner is EnemySpawnHandler)
                {
                    spawner.GetComponent<EnemySpawnHandler>().Inject(iSpawner);
                }
            }
        }

        private void InjectToEntities(Entity spawnedEntity)
        {
            if (spawnedEntity is Enemy)
            {
                IEnemyDamageReceiver enemyDamageReceiverI = new EnemyDamageReceiveService();
                IDespawner despawnerI = gameObject.AddComponent<EntityDespawnerService>();
                spawnedEntity.GetComponent<EnemyHealthHandler>().Inject(enemyDamageReceiverI);
                spawnedEntity.GetComponent<EntityDespawnHandler>().Inject(despawnerI);
            }
        }
    }
}