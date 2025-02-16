using ComponentScripts.Entities.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Interfaces.EnemyInterfaces.MovingInterfaces
{
    public interface IEnemyFollower
    {
        public void HandleFollowing(Enemy enemy, Transform character, Transform selfTransform,
            float distanceToStartFollowing, float increasedDistanceWhileFollowing,
            Rigidbody2D rigidBody,
            float followingSpeedIncrease, IEnemyMover enemyMover, NavMeshAgent agent, bool isInCollidesWithPlayer);
    }
}