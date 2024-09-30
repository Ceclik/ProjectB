using System.Collections;
using Services.BaseEntityServices;
using UnityEngine;

namespace ComponentScripts.Entities.Nest
{
    [RequireComponent(typeof(Nest))]
    public class EnemySpawnHandler : EntitySpawnHandler
    {
        [Space(10)] [Header("Spawn enemy info")] [SerializeField]
        private GameObject enemyToSpawn;

        [SerializeField] private float spawnFrequency;
        [SerializeField] private int amountOfEnemiesToSpawn;
        [SerializeField] private Transform enemiesParent;
        [SerializeField] private float distanceFromNest;

        private ISpawner _spawner;

        private void Start()
        {
            StartCoroutine(EnemiesSpawner());
        }

        public void Inject(ISpawner spawner)
        {
            _spawner = spawner;
        }

        private IEnumerator EnemiesSpawner()
        {
            while (gameObject.activeSelf)
            {
                yield return new WaitForSeconds(spawnFrequency);
                var spawnedEnemies =
                    _spawner.SpawnEntities(enemyToSpawn, amountOfEnemiesToSpawn, enemiesParent, transform.position,
                        distanceFromNest);
                foreach (var enemy in spawnedEnemies)
                    InvokeOnEntitySpawnEvent(enemy);
            }
        }
    }
}