using System.Collections;
using ComponentScripts.Entities.Enemies;
using Interfaces.EnemyInterfaces.MovingInterfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Services.EnemyServices.MovingScripts
{
    public class EnemyMoverService : MonoBehaviour, IEnemyMover
    {
        private bool _isSpeedIncreased;
        private float _lastSpeedIncreaseValue;

        public void Move(Vector2 targetPosition, Rigidbody2D rigidBody, NavMeshAgent agent, bool collidesWithPlayer,
            float speedIncrease = 0)
        {
            if (!_isSpeedIncreased && speedIncrease > 0)
            {
                _isSpeedIncreased = true;
                agent.speed += speedIncrease;
                _lastSpeedIncreaseValue = speedIncrease;
            }

            if (_isSpeedIncreased && speedIncrease == 0)
            {
                _isSpeedIncreased = false;
                agent.speed -= _lastSpeedIncreaseValue;
            }

            if (speedIncrease > 0 && collidesWithPlayer)
            {
                rigidBody.linearVelocity = Vector2.zero;
                return;
            }

            agent.SetDestination(targetPosition);

            var nextPosition = new Vector2(agent.nextPosition.x, agent.nextPosition.y);
            rigidBody.MovePosition(nextPosition);

            var direction = nextPosition - rigidBody.position;
            if (direction != Vector2.zero)
            {
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                rigidBody.rotation = angle;
            }
        }

        public void HandleMoving(Enemy enemy, Transform selfTransform, Transform[] points, ref int currentPointIndex,
            Rigidbody2D rigidBody, Animator animator, float onPointStayDelay, NavMeshAgent agent,
            bool isCollidesWithPlayer)
        {
            if (!enemy.IsFollowing &&
                Vector2.Distance(selfTransform.position, points[currentPointIndex].position) < 0.1f) //enter idle state
            {
                enemy.IsMoving = false;
                enemy.IsStaying = true;
                rigidBody.freezeRotation = true;
                rigidBody.bodyType = RigidbodyType2D.Kinematic;
                animator.ResetTrigger("Move");
                animator.SetTrigger("Stop");
                currentPointIndex = CountNextPointIndex(currentPointIndex, points.Length);
                StartCoroutine(DelayedMove(onPointStayDelay, enemy, animator, rigidBody));
            }

            if (enemy.IsMoving) //moving action
                Move(points[currentPointIndex].position, rigidBody, agent, isCollidesWithPlayer);
        }

        public int CountNextPointIndex(int currentIndex, int pointsAmount)
        {
            var newIndex = 0;
            if (pointsAmount > 1)
                do
                {
                    newIndex = Random.Range(0, pointsAmount);
                } while (newIndex == currentIndex);

            return newIndex;
        }

        private IEnumerator DelayedMove(float onPointStayDelay, Enemy enemy, Animator animator, Rigidbody2D rigidBody)
        {
            yield return new WaitForSeconds(onPointStayDelay);
            rigidBody.freezeRotation = false;
            rigidBody.bodyType = RigidbodyType2D.Dynamic;
            animator.SetTrigger("Move");
            animator.ResetTrigger("Stop");
            enemy.IsMoving = true;
            enemy.IsStaying = false;
        }
    }
}