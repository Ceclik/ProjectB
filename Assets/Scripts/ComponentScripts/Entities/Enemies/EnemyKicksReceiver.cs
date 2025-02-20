using System.Collections;
using UnityEngine;

namespace ComponentScripts.Entities.Enemies
{
    public class EnemyKicksReceiver : MonoBehaviour
    {
        [SerializeField] private float knockBackForce = 1.0f;
        [SerializeField] private float knockBackDuration = 0.3f;
        [SerializeField] private float afterKickStayingDelay = 0.18f;

        private EntityColorBlinker _colorBlinker;
        private EnemyMovingDelayer _movingDelayer;

        private void Start()
        {
            _colorBlinker = GetComponent<EntityColorBlinker>();
            _movingDelayer = GetComponent<EnemyMovingDelayer>();
        }

        public void ReceiveKick(Vector3 characterPosition)
        {
            Vector2 knockBackDirection = (transform.position - characterPosition).normalized;
            StartCoroutine(_colorBlinker.Blink());
            StartCoroutine(KnockBackRoutine(knockBackDirection, knockBackForce, knockBackDuration));
        }

        private IEnumerator KnockBackRoutine(Vector2 direction, float force, float duration)
        {
            var elapsedTime = 0f;
            Vector2 startPosition = transform.position;
            var targetPosition = startPosition + direction * force;

            while (elapsedTime < duration)
            {
                transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;

            StartCoroutine(_movingDelayer.StayingDelayed(afterKickStayingDelay));
        }
    }
}