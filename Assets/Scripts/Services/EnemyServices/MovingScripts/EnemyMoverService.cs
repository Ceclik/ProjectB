using System.Collections;
using ComponentScripts.Entities.Enemies;
using UnityEngine;

namespace Services.CharacterServices.MovingScripts
{
    public class EnemyMoverService : MonoBehaviour, IEnemyMover
    {
        public void Move(Vector2 targetPosition, Rigidbody2D rigidBody, float movingSpeed, float speedIncrease = 0)
        {
            var currentPosition = rigidBody.position;
            var direction = (targetPosition - currentPosition).normalized;
            var movement = direction * (movingSpeed + speedIncrease) * Time.fixedDeltaTime;
            rigidBody.MovePosition(currentPosition + movement);

            if (movement != Vector2.zero)
            {
                var angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90;
                rigidBody.rotation = angle;
            }
        }

        public void HandleMoving(Enemy enemy, Transform selfTransform, Transform[] points, ref int currentPointIndex,
            Rigidbody2D rigidBody, Animator animator, float onPointStayDelay)
        {
            if (!enemy.IsFollowing &&
                Vector2.Distance(selfTransform.position, points[currentPointIndex].position) < 0.1f) //enter idle state
            {
                enemy.IsMoving = false;
                enemy.IsStaying = true;
                rigidBody.freezeRotation = true;
                rigidBody.isKinematic = true;
                animator.ResetTrigger("Move");
                animator.SetTrigger("Stop");
                currentPointIndex = CountNextPointIndex(currentPointIndex, points.Length);
                StartCoroutine(DelayedMove(onPointStayDelay, enemy, animator, rigidBody));
            }

            if (enemy.IsMoving) //moving action
                Move(points[currentPointIndex].position, rigidBody, enemy.BaseMovingSpeed);
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
            rigidBody.isKinematic = false;
            animator.SetTrigger("Move");
            animator.ResetTrigger("Stop");
            enemy.IsMoving = true;
            enemy.IsStaying = false;
        }
    }
}