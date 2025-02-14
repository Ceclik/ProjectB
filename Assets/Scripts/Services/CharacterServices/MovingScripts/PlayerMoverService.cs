using System.Collections;
using ComponentScripts.CameraScripts;
using ComponentScripts.Entities.Character;
using Services.CharacterServices.CharacterStatsScripts;
using UnityEngine;

namespace Services.CharacterServices.MovingScripts
{
    public class PlayerMoverService : MonoBehaviour, IPlayerMover
    {
        private ArmorHandler _armorHandler;
        private CameraCharacterFollower _camera;

        private Rigidbody2D _rigidbody;
        private IStaminaHandler _staminaHandler;
        private CharacterStaminaHandler _staminaValues;
        private float _tugTimer;

        private void Start()
        {
            _staminaHandler = gameObject.AddComponent<StaminaHandlerService>();
            _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraCharacterFollower>();
            _staminaValues =
                GameObject.FindGameObjectWithTag("Player")
                    .GetComponent<CharacterStaminaHandler>();
            _armorHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<ArmorHandler>();
            _rigidbody = _staminaValues.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _tugTimer += Time.deltaTime;
        }

        public void MakeTug(Transform characterTransform, KeyCode key1, KeyCode key2, float tugSpeed, float tugDelay,
            float staminaDecreaseValue)
        {
            if (_tugTimer > tugDelay && _staminaValues.Stamina - staminaDecreaseValue >= 0)
            {
                _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                _tugTimer = 0;
                if ((key1 == KeyCode.A && key2 == KeyCode.W) || (key1 == KeyCode.W && key2 == KeyCode.A))
                {
                    var targetPosition = new Vector3(characterTransform.position.x - 3,
                        characterTransform.position.y + 3, characterTransform.position.z);
                    StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                }
                else if ((key1 == KeyCode.A && key2 == KeyCode.S) || (key1 == KeyCode.S && key2 == KeyCode.A))
                {
                    var targetPosition = new Vector3(characterTransform.position.x - 3,
                        characterTransform.position.y - 3, characterTransform.position.z);
                    StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                }
                else if ((key1 == KeyCode.W && key2 == KeyCode.D) || (key1 == KeyCode.D && key2 == KeyCode.W))
                {
                    var targetPosition = new Vector3(characterTransform.position.x + 3,
                        characterTransform.position.y + 3, characterTransform.position.z);
                    StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                }
                else if ((key1 == KeyCode.D && key2 == KeyCode.S) || (key1 == KeyCode.S && key2 == KeyCode.D))
                {
                    var targetPosition = new Vector3(characterTransform.position.x + 3,
                        characterTransform.position.y - 3, characterTransform.position.z);
                    StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                }
            }
        }

        public void Move(KeyCode key, float movingSpeed, Transform characterTransform, float runSpeed,
            float staminaDecreaseValue)
        {
            Vector3 movement;
            switch (key)
            {
                case KeyCode.W:
                    if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0 && !_armorHandler.IsUsingShield)
                    {
                        movement = new Vector3(0.0f, Time.fixedDeltaTime * runSpeed, 0.0f);
                        _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                        _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                    }
                    else
                    {
                        movement = new Vector3(0.0f, Time.fixedDeltaTime * movingSpeed, 0.0f);
                        _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                        //_rigidbody.velocity = movement * 50;
                    }

                    break;
                case KeyCode.A:
                    if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0 && !_armorHandler.IsUsingShield)
                    {
                        movement = new Vector3(-Time.fixedDeltaTime * runSpeed, 0.0f, 0.0f);
                        _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                        _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                    }
                    else
                    {
                        movement = new Vector3(-Time.fixedDeltaTime * movingSpeed, 0.0f, 0.0f);
                        _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                    }

                    break;
                case KeyCode.S:
                    if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0 && !_armorHandler.IsUsingShield)
                    {
                        movement = new Vector3(0.0f, -Time.fixedDeltaTime * runSpeed, 0.0f);
                        _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                        _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                    }
                    else
                    {
                        movement = new Vector3(0.0f, -Time.fixedDeltaTime * movingSpeed, 0.0f);
                        _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                    }

                    break;
                case KeyCode.D:
                    if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0 && !_armorHandler.IsUsingShield)
                    {
                        movement = new Vector3(Time.fixedDeltaTime * runSpeed, 0.0f, 0.0f);
                        _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                        _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                    }
                    else
                    {
                        movement = new Vector3(Time.fixedDeltaTime * movingSpeed, 0.0f, 0.0f);
                        _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                    }

                    break;
            }
        }

        public void Move(KeyCode key1, KeyCode key2, float movingSpeed, Transform characterTransform, float runSpeed,
            float staminaDecreaseValue)
        {
            Vector3 movement;
            if ((key1 == KeyCode.A && key2 == KeyCode.W) || (key1 == KeyCode.W && key2 == KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0 && !_armorHandler.IsUsingShield)
                {
                    movement = new Vector3(-Time.fixedDeltaTime * runSpeed, Time.fixedDeltaTime * runSpeed,
                        0.0f);
                    _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                    _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                }
                else
                {
                    movement = new Vector3(-Time.fixedDeltaTime * movingSpeed,
                        Time.fixedDeltaTime * movingSpeed,
                        0.0f);
                    _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                }
            }
            else if ((key1 == KeyCode.A && key2 == KeyCode.S) || (key1 == KeyCode.S && key2 == KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0 && !_armorHandler.IsUsingShield)
                {
                    movement = new Vector3(-Time.fixedDeltaTime * runSpeed, -Time.fixedDeltaTime * runSpeed,
                        0.0f);
                    _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                    _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                }
                else
                {
                    movement = new Vector3(-Time.fixedDeltaTime * movingSpeed,
                        -Time.fixedDeltaTime * movingSpeed,
                        0.0f);
                    _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                }
            }
            else if ((key1 == KeyCode.W && key2 == KeyCode.D) || (key1 == KeyCode.D && key2 == KeyCode.W))
            {
                if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0 && !_armorHandler.IsUsingShield)
                {
                    movement = new Vector3(Time.fixedDeltaTime * runSpeed, Time.fixedDeltaTime * runSpeed,
                        0.0f);
                    _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                    _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                }
                else
                {
                    movement = new Vector3(Time.fixedDeltaTime * movingSpeed, Time.fixedDeltaTime * movingSpeed,
                        0.0f);
                    _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                }
            }
            else if ((key1 == KeyCode.D && key2 == KeyCode.S) || (key1 == KeyCode.S && key2 == KeyCode.D))
            {
                if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0 && !_armorHandler.IsUsingShield)
                {
                    movement = new Vector3(Time.fixedDeltaTime * runSpeed, -Time.fixedDeltaTime * runSpeed,
                        0.0f);
                    _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                    _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                }
                else
                {
                    movement = new Vector3(Time.fixedDeltaTime * movingSpeed,
                        -Time.fixedDeltaTime * movingSpeed,
                        0.0f);
                    _rigidbody.MovePosition(_rigidbody.position + (Vector2)movement);
                }
            }
        }

        public void Inject(IStaminaHandler staminaHandler)
        {
            _staminaHandler = staminaHandler;
        }

        public void MakeTug(Transform characterTransform, KeyCode key, float tugSpeed, float tugDelay,
            float staminaDecreaseValue)
        {
            if (_tugTimer > tugDelay && _staminaValues.Stamina - staminaDecreaseValue >= 0)
            {
                _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                _tugTimer = 0;
                Vector3 targetPosition;
                switch (key)
                {
                    case KeyCode.W:
                        targetPosition = new Vector3(characterTransform.position.x,
                            characterTransform.position.y + 3, characterTransform.position.z);
                        StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                        break;
                    case KeyCode.D:
                        targetPosition = new Vector3(characterTransform.position.x + 3,
                            characterTransform.position.y, characterTransform.position.z);
                        StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                        break;
                    case KeyCode.S:
                        targetPosition = new Vector3(characterTransform.position.x,
                            characterTransform.position.y - 3, characterTransform.position.z);
                        StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                        break;
                    case KeyCode.A:
                        targetPosition = new Vector3(characterTransform.position.x - 3,
                            characterTransform.position.y, characterTransform.position.z);
                        StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                        break;
                }
            }
        }

        private IEnumerator TugMaker(Vector3 targetPosition, Transform characterTransform, float tugSpeed)
        {
            _camera.StartDash();
            while (characterTransform.position != targetPosition)
            {
                yield return new WaitForEndOfFrame();
                characterTransform.position =
                    Vector3.MoveTowards(characterTransform.position, targetPosition, Time.fixedDeltaTime * tugSpeed);
            }

            _camera.EndDash();
        }
    }
}