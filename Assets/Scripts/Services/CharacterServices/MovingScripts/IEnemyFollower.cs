using ComponentScripts.Entities.Enemies;
using UnityEngine;

namespace Services.CharacterServices.MovingScripts
{
    public interface IEnemyFollower
    {
        public void HandleFollowing(Enemy enemy, Transform character, Transform selfTransform, float distanceToFollow,
            Rigidbody2D rigidBody,
            float followingSpeedIncrease, IEnemyMover enemyMover);
    }
}