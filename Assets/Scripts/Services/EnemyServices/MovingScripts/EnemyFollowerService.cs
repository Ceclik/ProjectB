using ComponentScripts.Entities.Enemies;
using Interfaces.EnemyInterfaces.MovingInterfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Services.EnemyServices.MovingScripts
{
    public class EnemyFollowerService : IEnemyFollower
    {
        public void HandleFollowing(Enemy enemy, Transform character, Transform selfTransform,
            float distanceToStartFollowing, float increasedDistanceWhileFollowing,
            Rigidbody2D rigidBody,
            float followingSpeedIncrease, IEnemyMover enemyMover, NavMeshAgent agent, bool isInCollidesWithPlayer)
        {
            if (!enemy.IsStaying &&
                Vector2.Distance(character.position, selfTransform.position) <
                distanceToStartFollowing) //enter in following state
            {
                if (!enemy.IsFollowing)
                {
                    enemy.IsMoving = false;
                    enemy.IsFollowing = true;
                }
            }
            else if (enemy.IsFollowing &&
                     Vector2.Distance(character.position, selfTransform.position) >
                     increasedDistanceWhileFollowing) //exit from following state
            {
                enemy.IsFollowing = false;
                enemy.IsMoving = true;
            }
            
            if (enemy.IsFollowing)
                enemyMover.Move(character.position, rigidBody, agent, isInCollidesWithPlayer,
                    followingSpeedIncrease);
        }
    }
}