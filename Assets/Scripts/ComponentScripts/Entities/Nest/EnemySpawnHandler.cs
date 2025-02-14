using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ComponentScripts.Entities.Enemies;
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
        [SerializeField] private int maxNestSpawnedAmount;

        [Space(10)] [SerializeField] private bool allowSpawn;
        [SerializeField] private float maxDistanceToSpawn;
        private Transform _character;
        private List<GameObject> _spawnedEnemies;

        private ISpawner _spawner;

        private void Start()
        {
            _character = GameObject.FindGameObjectWithTag("Player").transform;
            _spawner = gameObject.AddComponent<SpawnerService>();
            _spawnedEnemies = new List<GameObject>();
            StartCoroutine(EnemiesSpawner());
        }

        private void FixedUpdate()
        {
            if (allowSpawn && Vector2.Distance(transform.position, _character.position) > maxDistanceToSpawn)
                allowSpawn = false;
            if (!allowSpawn && Vector2.Distance(transform.position, _character.position) < maxDistanceToSpawn)
                allowSpawn = true;
        }

        private IEnumerator EnemiesSpawner()
        {
            while (gameObject.activeSelf)
            {
                yield return new WaitForSeconds(spawnFrequency);

                foreach (var enemy in _spawnedEnemies.ToList())
                    if (enemy == null)
                        _spawnedEnemies.Remove(enemy);

                if (allowSpawn && _spawnedEnemies.Count < maxNestSpawnedAmount)
                {
                    var actualAmountToSpawn = maxNestSpawnedAmount - _spawnedEnemies.Count > 3
                        ? amountOfEnemiesToSpawn
                        : maxNestSpawnedAmount - _spawnedEnemies.Count;

                    foreach (var enemy in _spawner.SpawnEntities(enemyToSpawn, actualAmountToSpawn, enemiesParent,
                                 transform.position,
                                 distanceFromNest))
                        if (enemy != null)
                        {
                            enemy.GetComponent<Enemy>().Nest = transform;
                            _spawnedEnemies.Add(enemy.gameObject);
                        }
                }
            }
        }
    }
}