using Services.CharacterServices.MovingScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Enemies
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private float onPointStayDelay;
        private Animator _animator;
        private int _currentPointIndex;
        private Enemy _enemy;
        private IEnemyMover _enemyMover;
        private Transform[] _points;

        private Transform _pointsParent;
        private Rigidbody2D _rigidBody;

        private void Start()
        {
            _enemyMover = gameObject.AddComponent<EnemyMoverService>();

            _enemy = GetComponent<Enemy>();
            _pointsParent = _enemy.Nest.GetComponentsInChildren<Transform>()[1];
            _points = new Transform[_pointsParent.childCount];
            _rigidBody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            for (var i = 0; i < _pointsParent.childCount; i++)
                _points[i] = _pointsParent.GetChild(i);
            _currentPointIndex = _enemyMover.CountNextPointIndex(0, _points.Length);
            _enemy.IsMoving = true;
            _enemy.IsFollowing = false;
            _enemy.IsStaying = false;
            _animator.SetTrigger("Move");
        }

        private void FixedUpdate()
        {
            _enemyMover.HandleMoving(_enemy, transform, _points, ref _currentPointIndex, _rigidBody, _animator,
                onPointStayDelay);
        }
    }
}