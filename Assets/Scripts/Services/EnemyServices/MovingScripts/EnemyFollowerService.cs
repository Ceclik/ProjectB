using ComponentScripts.Entities.Enemies;
using Interfaces.EnemyInterfaces.MovingInterfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Services.EnemyServices.MovingScripts
{
    public class EnemyFollowerService : IEnemyFollower
    {
        public void HandleFollowing(Enemy enemy, Transform character, Transform selfTransform, float distanceToFollow,
            Rigidbody2D rigidBody,
            float followingSpeedIncrease, IEnemyMover enemyMover, NavMeshAgent agent)
        {
            if (!enemy.IsStaying &&
                Vector2.Distance(character.position, selfTransform.position) <
                distanceToFollow) //enter in following state
            {
                if (!enemy.IsFollowing)
                {
                    enemy.IsMoving = false;
                    enemy.IsFollowing = true;
                }

                if (enemy.IsFollowing)
                    enemyMover.Move(character.position, rigidBody, enemy.BaseMovingSpeed, agent, followingSpeedIncrease);
            }
            else if (enemy.IsFollowing &&
                     Vector2.Distance(character.position, selfTransform.position) >
                     distanceToFollow) //exit from following state
            {
                enemy.IsFollowing = false;
                enemy.IsMoving = true;
            }
        }
    }
}