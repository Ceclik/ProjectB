using ComponentScripts.Entities.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Interfaces.EnemyInterfaces.MovingInterfaces
{
    public interface IEnemyMover
    {
        public void Move(Vector2 targetPosition, Rigidbody2D rigidBody, float movingSpeed, NavMeshAgent agent, float speedIncrease = 0);

        public void HandleMoving(Enemy enemy, Transform selfTransform, Transform[] points, ref int currentPointIndex,
            Rigidbody2D rigidBody, Animator animator, float onPointStayDelay, NavMeshAgent agent);

        public int CountNextPointIndex(int currentIndex, int pointsAmount);
    }
}