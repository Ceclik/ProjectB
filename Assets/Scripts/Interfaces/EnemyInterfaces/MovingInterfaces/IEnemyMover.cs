using ComponentScripts.Entities.Enemies;
using UnityEngine;

namespace Services.CharacterServices.MovingScripts
{
    public interface IEnemyMover
    {
        public void Move(Vector2 targetPosition, Rigidbody2D rigidBody, float movingSpeed, float speedIncrease = 0);

        public void HandleMoving(Enemy enemy, Transform selfTransform, Transform[] points, ref int currentPointIndex,
            Rigidbody2D rigidBody, Animator animator, float onPointStayDelay);

        public int CountNextPointIndex(int currentIndex, int pointsAmount);
    }
}