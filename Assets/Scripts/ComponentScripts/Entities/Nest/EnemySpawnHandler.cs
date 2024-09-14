using System.Collections;
using Services.BaseEntityServices;
using UnityEngine;

namespace ComponentScripts.Entities.Nest
{
    [RequireComponent(typeof(Nest))]
    public class EnemySpawnHandler : MonoBehaviour
    {
        [Space(10)] [Header("Spawn enemy info")] [SerializeField]
        private GameObject enemyToSpawn;
        [SerializeField] private float spawnFrequency;
        [SerializeField] private int amountOfEnemiesToSpawn;
        [SerializeField] private Transform enemiesParent;
        [SerializeField] private float distanceFromNest;

        private ISpawner _spawner;

        public void Inject(ISpawner spawner)
        {
            _spawner = spawner;
        }

        private void Start()
        {
            StartCoroutine(EnemiesSpawner());
        }

        private IEnumerator EnemiesSpawner()
        {
            while (gameObject.activeSelf)
            {
                yield return new WaitForSeconds(spawnFrequency);
                _spawner.SpawnEntities(enemyToSpawn, amountOfEnemiesToSpawn, enemiesParent, transform.position,
                    distanceFromNest);
            }
        }
    }
}