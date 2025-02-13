using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ComponentScripts.Entities.Enemies
{
    public class EnemyMover : MonoBehaviour
    {
        private Transform _pointsParent;
        private Transform[] _points;
        private int _currentPointIndex;
        private Enemy _enemy;
        private Rigidbody2D _rigidbody;
        private bool _isMoving;
        private bool _isStaying;
        private Animator _animator;
        private bool _isFollowing;
        private Transform _character;
        [SerializeField] private float onPointStayDelay;
        [SerializeField] private float distanceToFollow;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _pointsParent = _enemy.Nest.GetComponentsInChildren<Transform>()[1];
            _points = new Transform[_pointsParent.childCount];
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _character = GameObject.FindGameObjectWithTag("Player").transform;
            for (int i = 0; i < _pointsParent.childCount; i++)
                _points[i] = _pointsParent.GetChild(i);
            _currentPointIndex = CountNextPointIndex(0);
            _isMoving = true;
            _isFollowing = false;
            _isStaying = false;
            _animator.SetTrigger("Move");
        }

        private int CountNextPointIndex(int currentIndex)
        {
            int newIndex = 0;
            if (_pointsParent.childCount > 1)
                do
                    newIndex = Random.Range(0, _pointsParent.childCount);
                while (newIndex == currentIndex);
            return newIndex;
        }

        private void FixedUpdate()
        {
            if (!_isFollowing && !_isStaying && Vector2.Distance(transform.position, _character.position) < distanceToFollow)
            {
                _isMoving = false;
                _isFollowing = true;
                Vector2 targetPosition = _character.position;
                Vector2 currentPosition = _rigidbody.position;
                Vector2 direction = (targetPosition - currentPosition).normalized;
                Vector2 movement = direction * _enemy.BaseMovingSpeed * Time.fixedDeltaTime;
                _rigidbody.MovePosition(currentPosition + movement);
                
                if (movement != Vector2.zero)
                {
                    float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90;
                    _rigidbody.rotation = angle;
                }
            }
            else if (_isFollowing && Vector2.Distance(transform.position, _character.position) > distanceToFollow)
            {
                _isMoving = true;
                _isFollowing = false;
            }
            
            if (!_isFollowing && Vector2.Distance(transform.position, _points[_currentPointIndex].position) < 0.1f)
            {
                _isMoving = false;
                _isStaying = true;
                _rigidbody.freezeRotation = true;
                _rigidbody.isKinematic = true;
                _animator.ResetTrigger("Move");
                _animator.SetTrigger("Stop");
                _currentPointIndex = CountNextPointIndex(_currentPointIndex);
                StartCoroutine(DelayedMove());
            }

            if (_isMoving)
            {
                Vector2 targetPosition = _points[_currentPointIndex].position;
                Vector2 currentPosition = _rigidbody.position;
                Vector2 direction = (targetPosition - currentPosition).normalized;
                Vector2 movement = direction * _enemy.BaseMovingSpeed * Time.fixedDeltaTime;

                _rigidbody.MovePosition(currentPosition + movement);

                if (movement != Vector2.zero)
                {
                    float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90;
                    _rigidbody.rotation = angle;
                }
            }
        }

        private IEnumerator DelayedMove()
        {
            yield return new WaitForSeconds(onPointStayDelay);
            _rigidbody.freezeRotation = false;
            _rigidbody.isKinematic = false;
            _animator.SetTrigger("Move");
            _animator.ResetTrigger("Stop");
            _isMoving = true;
            _isStaying = false;
        }
    }
}