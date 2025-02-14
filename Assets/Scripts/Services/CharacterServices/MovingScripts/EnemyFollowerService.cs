using ComponentScripts.Entities.Enemies;
using UnityEngine;

namespace Services.CharacterServices.MovingScripts
{
    public class EnemyFollowerService : IEnemyFollower
    {
        public void HandleFollowing(Enemy enemy, Transform character, Transform selfTransform, float distanceToFollow,
            Rigidbody2D rigidBody,
            float followingSpeedIncrease, IEnemyMover enemyMover)
        {
            if (!enemy.IsStaying &&
                Vector2.Distance(character.position, selfTransform.position) <
                distanceToFollow) //enter in following state
            {
                if (!enemy.IsFollowing)
                {
                    enemy.IsFollowing = true;
                    enemy.IsMoving = false;
                }

                if (enemy.IsFollowing)
                    enemyMover.Move(character.position, rigidBody, enemy.BaseMovingSpeed, followingSpeedIncrease);
            }
            else if (enemy.IsFollowing &&
                     Vector2.Distance(character.position, selfTransform.position) >
                     distanceToFollow) //exit from following state
            {
                enemy.IsMoving = true;
                enemy.IsFollowing = false;
            }
        }
    }
}