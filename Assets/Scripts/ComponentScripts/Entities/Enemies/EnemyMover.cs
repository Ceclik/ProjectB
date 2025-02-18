using Interfaces.EnemyInterfaces.MovingInterfaces;
using Services.EnemyServices.MovingScripts;
using UnityEngine;
using UnityEngine.AI;

namespace ComponentScripts.Entities.Enemies
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private float onPointStayDelay;
        private NavMeshAgent _agent;
        private EnemyAnimationsHandler _animator;
        private int _currentPointIndex;
        private Enemy _enemy;
        private Transform[] _points;
        private Transform _pointsParent;
        private Rigidbody2D _rigidBody;
        public bool IsInCollisionWithPlayer { get; private set; }
        public IEnemyMover EnemyMoverService { get; private set; }

        private void Start()
        {
            EnemyMoverService = gameObject.AddComponent<EnemyMoverService>();
            _agent = GetComponent<NavMeshAgent>();
            _enemy = GetComponent<Enemy>();
            _pointsParent = _enemy.Nest.GetComponentsInChildren<Transform>()[1];
            _points = new Transform[_pointsParent.childCount];
            _rigidBody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<EnemyAnimationsHandler>();
            for (var i = 0; i < _pointsParent.childCount; i++)
                _points[i] = _pointsParent.GetChild(i);
            _currentPointIndex = EnemyMoverService.CountNextPointIndex(0, _points.Length);
            _enemy.IsMoving = true;
            _enemy.IsFollowing = false;
            _enemy.IsStaying = false;
            _animator.TurnMoveAnimation();

            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _agent.speed = _enemy.BaseMovingSpeed;
        }

        private void FixedUpdate()
        {
            EnemyMoverService.HandleMoving(_enemy, transform, _points, ref _currentPointIndex, _rigidBody, _animator,
                onPointStayDelay, _agent, IsInCollisionWithPlayer);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
                IsInCollisionWithPlayer = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
                IsInCollisionWithPlayer = false;
        }
    }
}