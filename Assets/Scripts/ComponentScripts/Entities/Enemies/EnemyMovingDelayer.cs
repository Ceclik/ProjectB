using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace ComponentScripts.Entities.Enemies
{
    public class EnemyMovingDelayer : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private EnemyAnimationsHandler _animations;
        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _agent = GetComponent<NavMeshAgent>();
            _animations = GetComponent<EnemyAnimationsHandler>();
        }


        public IEnumerator StayingDelayed(float delay)
        {
            _animations.TurnStayAnimation();
            _enemy.IsFollowing = false;
            _enemy.IsStaying = true;
            _agent.enabled = false;

            yield return new WaitForSeconds(delay);

            _animations.TurnMoveAnimation();
            _agent.enabled = true;
            _enemy.IsFollowing = true;
            _enemy.IsStaying = false;
        }
    }
}