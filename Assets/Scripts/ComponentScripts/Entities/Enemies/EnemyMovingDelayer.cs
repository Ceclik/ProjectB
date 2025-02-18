using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace ComponentScripts.Entities.Enemies
{
    public class EnemyMovingDelayer : MonoBehaviour
    {
        private Enemy _enemy;
        private NavMeshAgent _agent;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _agent = GetComponent<NavMeshAgent>();
        }
        

        public IEnumerator StayingDelayed(float delay)
        {
            _enemy.IsFollowing = false;
            _enemy.IsStaying = true;
            _agent.enabled = false;
            
            yield return new WaitForSeconds(delay);
            
            _agent.enabled = true;
            _enemy.IsFollowing = true;
            _enemy.IsStaying = false;
        }
    }
}