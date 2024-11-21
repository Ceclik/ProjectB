using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private Transform character;

        private ISpawner _spawner;
        private List<GameObject> _spawnedEnemies;

        private void Start()
        {
            _spawner = gameObject.AddComponent<SpawnerService>();
            _spawnedEnemies = new List<GameObject>();
            StartCoroutine(EnemiesSpawner());
        }

        private float CountDistance(float deltaX, float deltaY)
        {
            return Mathf.Sqrt(Mathf.Abs(deltaX * deltaX) + Mathf.Abs(deltaY * deltaY));
        }

        private void FixedUpdate()
        {
            float deltaX = transform.position.x - character.position.x;
            float deltaY = transform.position.y - character.position.y;
            if (CountDistance(deltaX, deltaY) > maxDistanceToSpawn)
            {
                allowSpawn = false;
            }
            else allowSpawn = true;
        }

        private IEnumerator EnemiesSpawner()
        {
            while (gameObject.activeSelf)
            {
                yield return new WaitForSeconds(spawnFrequency);
                
                foreach (var enemy in _spawnedEnemies.ToList())
                    if (enemy == null)
                        _spawnedEnemies.Remove(enemy);
                
                if (allowSpawn &&  _spawnedEnemies.Count < maxNestSpawnedAmount)
                {
                    int actualAmountToSpawn = maxNestSpawnedAmount - _spawnedEnemies.Count > 3
                        ? amountOfEnemiesToSpawn
                        : maxNestSpawnedAmount - _spawnedEnemies.Count;
                    
                    foreach (var enemy in _spawner.SpawnEntities(enemyToSpawn, actualAmountToSpawn, enemiesParent,
                                 transform.position,
                                 distanceFromNest))
                    {
                        if(enemy != null)
                            _spawnedEnemies.Add(enemy.gameObject);
                        
                    }
                }

            }
        }
    }
}