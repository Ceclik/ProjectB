using UnityEngine;

namespace ComponentScripts.CameraScripts
{
    public class CameraCharacterFollower : MonoBehaviour
    {
        [SerializeField] private float smoothTime = 0.2f; // Время, за которое камера догоняет игрока
        [SerializeField] private Vector2 offset = new(0, 0); // Смещение камеры относительно игрока
        private Transform _characterTransform;

        private bool _isTuging;
        private Vector3 _velocity = Vector3.zero;

        private void Start()
        {
            _characterTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void LateUpdate()
        {
            var targetPosition =
                _characterTransform.position +
                new Vector3(offset.x, offset.y, -10f); // Установка позиции цели камеры (с учётом смещения)
            transform.position = _isTuging
                ? targetPosition
                : Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity,
                    smoothTime); // Плавное перемещение
        }

        public void StartDash()
        {
            _isTuging = true;
        }

        public void EndDash()
        {
            _isTuging = false;
        }
    }
}