using ComponentScripts.Entities.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Interfaces.EnemyInterfaces.MovingInterfaces
{
    public interface IEnemyFollower
    {
        public void HandleFollowing(Enemy enemy, Transform character, Transform selfTransform, float distanceToFollow,
            Rigidbody2D rigidBody,
            float followingSpeedIncrease, IEnemyMover enemyMover, NavMeshAgent agent, bool isInCollidesWithPlayer);
    }
}