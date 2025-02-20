using System.Collections;
using ComponentScripts.CameraScripts;
using ComponentScripts.Entities.Character;
using Interfaces.CharacterInterfaces.MovingInterfaces;
using Services.CharacterServices.CharacterStatsScripts;
using UnityEngine;

namespace Services.CharacterServices.MovingScripts
{
    public class PlayerMoverService : MonoBehaviour, IPlayerMover
    {
        private ArmorHandler _armorHandler;
        private CameraCharacterFollower _camera;
        private bool _isControllingAllowed;
        private Rigidbody2D _rigidBody;
        private IStaminaHandler _staminaHandler;
        private CharacterStaminaHandler _staminaValues;
        private float _tugTimer;

        private void Start()
        {
            _isControllingAllowed = true;
            _staminaHandler = gameObject.AddComponent<StaminaHandlerService>();
            _camera = Camera.main?.GetComponent<CameraCharacterFollower>();
            _staminaValues = GetComponent<CharacterStaminaHandler>();
            _armorHandler = GetComponent<ArmorHandler>();
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _tugTimer += Time.deltaTime;
        }

        public void MakeTug(Transform characterTransform, KeyCode key1, KeyCode key2, float tugSpeed, float tugDelay,
            float staminaDecreaseValue)
        {
            if (_isControllingAllowed && _tugTimer > tugDelay && _staminaValues.Stamina - staminaDecreaseValue >= 0)
            {
                _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                _tugTimer = 0;

                var direction = GetDirection(key1, key2);
                if (direction != Vector3.zero)
                {
                    var targetPosition = characterTransform.position + direction * 3;
                    StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                }
            }
        }

        public void Move(KeyCode key, float movingSpeed, Transform characterTransform, float runSpeed,
            float staminaDecreaseValue)
        {
            var direction = GetDirection(key);
            if (_isControllingAllowed && direction != Vector3.zero)
            {
                var isRunning = Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0 &&
                                !_armorHandler.IsUsingShield;
                var speed = isRunning ? runSpeed : movingSpeed;

                var movement = direction * (Time.fixedDeltaTime * speed);
                _rigidBody.MovePosition(_rigidBody.position + (Vector2)movement);

                if (isRunning) _staminaHandler.DecreaseStamina(staminaDecreaseValue);
            }
        }

        public void Move(KeyCode key1, KeyCode key2, float movingSpeed, Transform characterTransform, float runSpeed,
            float staminaDecreaseValue)
        {
            var direction = GetDirection(key1, key2);
            if (_isControllingAllowed && direction != Vector3.zero)
            {
                var isRunning = Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0 &&
                                !_armorHandler.IsUsingShield;
                var speed = isRunning ? runSpeed : movingSpeed;

                var movement = direction * (Time.fixedDeltaTime * speed);
                _rigidBody.MovePosition(_rigidBody.position + (Vector2)movement);

                if (isRunning) _staminaHandler.DecreaseStamina(staminaDecreaseValue);
            }
        }

        public void Inject(IStaminaHandler staminaHandler)
        {
            _staminaHandler = staminaHandler;
        }

        public void MakeTug(Transform characterTransform, KeyCode key, float tugSpeed, float tugDelay,
            float staminaDecreaseValue)
        {
            if (_isControllingAllowed && _tugTimer > tugDelay && _staminaValues.Stamina - staminaDecreaseValue >= 0)
            {
                _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                _tugTimer = 0;

                var direction = GetDirection(key);
                if (direction != Vector3.zero)
                {
                    var targetPosition = characterTransform.position + direction * 3;
                    StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                }
            }
        }

        public void ApplyKnockBack(Vector2 direction, float force, float duration)
        {
            StartCoroutine(KnockbackRoutine(direction, force, duration));
        }

        private IEnumerator TugMaker(Vector3 targetPosition, Transform characterTransform, float tugSpeed)
        {
            //_camera.StartDash();
            while (characterTransform.position != targetPosition)
            {
                yield return new WaitForEndOfFrame();
                characterTransform.position = Vector3.MoveTowards(characterTransform.position, targetPosition,
                    Time.fixedDeltaTime * tugSpeed);
            }

            //_camera.EndDash();
        }

        private Vector3 GetDirection(KeyCode key)
        {
            switch (key)
            {
                case KeyCode.W: return Vector3.up;
                case KeyCode.S: return Vector3.down;
                case KeyCode.A: return Vector3.left;
                case KeyCode.D: return Vector3.right;
                default: return Vector3.zero;
            }
        }

        private Vector3 GetDirection(KeyCode key1, KeyCode key2)
        {
            var dir1 = GetDirection(key1);
            var dir2 = GetDirection(key2);
            return (dir1 + dir2).normalized;
        }

        private IEnumerator KnockbackRoutine(Vector2 direction, float force, float duration)
        {
            var elapsedTime = 0f;
            Vector2 startPosition = transform.position;
            var targetPosition = startPosition + direction * force;
            _isControllingAllowed = false;
            while (elapsedTime < duration)
            {
                transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _isControllingAllowed = true;
            transform.position = targetPosition;
        }
    }
}