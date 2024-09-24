using System.Collections.Generic;
using ComponentScripts;
using ComponentScripts.Entities;
using ComponentScripts.Entities.Character;
using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Entities.Enemies;
using ComponentScripts.Entities.Nest;
using Services.BaseEntityServices;
using Services.CharacterServices.CharacterAttackScripts;
using Services.CharacterServices.CharacterStatsScripts;
using Services.CharacterServices.InventoryScripts;
using Services.CharacterServices.MovingScripts;
using Services.CharacterServices.UIScripts;
using UnityEngine;

namespace Injectors
{
    public class Injector : MonoBehaviour
    {
        [SerializeField] private CharacterMover character;
        //[SerializeField] private GameObject mainCanvas;
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

            IActionTextHandler actionTextHandlerI = new ActionTextHandlerService();
            ActionTextHandler actionTextHandler = character.GetComponent<ActionTextHandler>();
            actionTextHandler.Inject(actionTextHandlerI);

            IInventoryHandler inventoryHandlerI = new InventoryHandlerService();
            ItemsPicker itemsPicker = character.GetComponent<ItemsPicker>();
            itemsPicker.Inject(inventoryHandlerI);
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
            IEntityDamageReceiver entityDamageReceiverI = new EntityDamageReceiveService();
            IDespawner despawnerI = gameObject.AddComponent<EntityDespawnerService>();
            foreach (var spawner in spawners)
            {
                if (spawner is EnemySpawnHandler)
                {
                    spawner.GetComponent<EnemySpawnHandler>().Inject(iSpawner);
                    spawner.GetComponent<EntityHealthHandler>().Inject(entityDamageReceiverI);
                    spawner.GetComponent<EntityDespawnHandler>().Inject(despawnerI);
                }
            }
        }

        private void InjectToEntities(Entity spawnedEntity)
        {
            if (spawnedEntity is Enemy)
            {
                IEntityDamageReceiver entityDamageReceiverI = new EntityDamageReceiveService();
                IDespawner despawnerI = gameObject.AddComponent<EntityDespawnerService>();
                spawnedEntity.GetComponent<EntityHealthHandler>().Inject(entityDamageReceiverI);
                spawnedEntity.GetComponent<EntityDespawnHandler>().Inject(despawnerI);
            }
        }
    }
}