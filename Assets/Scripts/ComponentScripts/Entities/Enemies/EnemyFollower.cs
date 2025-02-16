using Interfaces.EnemyInterfaces.MovingInterfaces;
using Services.EnemyServices.MovingScripts;
using UnityEngine;
using UnityEngine.AI;

namespace ComponentScripts.Entities.Enemies
{
    public class EnemyFollower : MonoBehaviour
    {
        [SerializeField] private float distanceToFollow;
        [SerializeField] private float followingSpeedIncrease;
        private NavMeshAgent _agent;
        private Transform _character;

        private Enemy _enemy;
        private IEnemyFollower _enemyFollower;

        private EnemyMover _enemyMover;
        private Rigidbody2D _rigidBody;

        private void Start()
        {
            _enemyMover = gameObject.GetComponent<EnemyMover>();
            _enemyFollower = new EnemyFollowerService();
            _agent = GetComponent<NavMeshAgent>();
            _enemy = GetComponent<Enemy>();
            _character = GameObject.FindGameObjectWithTag("Player").transform;
            _rigidBody = GetComponent<Rigidbody2D>();

            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _agent.speed = _enemy.BaseMovingSpeed;
        }

        private void FixedUpdate()
        {
            _enemyFollower.HandleFollowing(_enemy, _character, transform, distanceToFollow, _rigidBody,
                followingSpeedIncrease,
                _enemyMover.EnemyMoverService, _agent, _enemyMover.IsInCollisionWithPlayer);
        }
    }
}