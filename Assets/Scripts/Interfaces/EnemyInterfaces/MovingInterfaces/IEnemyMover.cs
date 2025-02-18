using ComponentScripts.Entities.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Interfaces.EnemyInterfaces.MovingInterfaces
{
    public interface IEnemyMover
    {
        public void Move(Vector2 targetPosition, Rigidbody2D rigidBody, NavMeshAgent agent, bool collidesWithPlayer,
            float speedIncrease = 0);

        public void HandleMoving(Enemy enemy, Transform selfTransform, Transform[] points, ref int currentPointIndex,
            Rigidbody2D rigidBody, EnemyAnimationsHandler animator, float onPointStayDelay, NavMeshAgent agent,
            bool isCollidesWithPlayer);

        public int CountNextPointIndex(int currentIndex, int pointsAmount);
    }
}