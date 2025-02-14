using Interfaces.EnemyInterfaces.MovingInterfaces;
using Services.EnemyServices.MovingScripts;
using UnityEngine;
using UnityEngine.AI;

namespace ComponentScripts.Entities.Enemies
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private float onPointStayDelay;
        private Animator _animator;
        private int _currentPointIndex;
        private Enemy _enemy;
        public IEnemyMover EnemyMoverService { get; private set; }
        private Transform[] _points;
        private NavMeshAgent _agent;
        private Transform _pointsParent;
        private Rigidbody2D _rigidBody;

        private void Start()
        {
            EnemyMoverService = gameObject.AddComponent<EnemyMoverService>();
            _agent = GetComponent<NavMeshAgent>();
            _enemy = GetComponent<Enemy>();
            _pointsParent = _enemy.Nest.GetComponentsInChildren<Transform>()[1];
            _points = new Transform[_pointsParent.childCount];
            _rigidBody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            for (var i = 0; i < _pointsParent.childCount; i++)
                _points[i] = _pointsParent.GetChild(i);
            _currentPointIndex = EnemyMoverService.CountNextPointIndex(0, _points.Length);
            _enemy.IsMoving = true;
            _enemy.IsFollowing = false;
            _enemy.IsStaying = false;
            _animator.SetTrigger("Move");
            
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _agent.speed = _enemy.BaseMovingSpeed;
        }

        private void FixedUpdate()
        {
            EnemyMoverService.HandleMoving(_enemy, transform, _points, ref _currentPointIndex, _rigidBody, _animator,
                onPointStayDelay, _agent);
        }
    }
}