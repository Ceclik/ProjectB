using Services.CharacterServices.MovingScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Enemies
{
    public class EnemyFollower : MonoBehaviour
    {
        [SerializeField] private float distanceToFollow;
        [SerializeField] private float followingSpeedIncrease;
        private Transform _character;

        private Enemy _enemy;
        private IEnemyFollower _enemyFollower;

        private IEnemyMover _enemyMover;
        private Rigidbody2D _rigidBody;

        private void Start()
        {
            _enemyMover = gameObject.AddComponent<EnemyMoverService>();
            _enemyFollower = new EnemyFollowerService();

            _enemy = GetComponent<Enemy>();
            _character = GameObject.FindGameObjectWithTag("Player").transform;
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _enemyFollower.HandleFollowing(_enemy, _character, transform, distanceToFollow, _rigidBody,
                followingSpeedIncrease,
                _enemyMover);
        }
    }
}