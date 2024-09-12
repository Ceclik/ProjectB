using System;
using System.Collections;
using ComponentScripts.Entities.Character;
using Services.UI;
using UnityEngine;

namespace Services.MovingScripts
{
    public class PlayerMover : MonoBehaviour, IPlayerMover
    {
        private IStaminaHandler _staminaHandler;
        private float _tugTimer;
        private CharacterStaminaHandler _staminaValues;

        private void Start()
        {
            _staminaValues = GameObject.Find("Character").GetComponent<CharacterStaminaHandler>(); //TODO remake for multiplayer
        }

        public void Inject(IStaminaHandler staminaHandler)
        {
            _staminaHandler = staminaHandler;
        }
        
        private void Update()
        {
            _tugTimer += Time.deltaTime;
        }

        public void MakeTug(Transform characterTransform, KeyCode key1, KeyCode key2, float tugSpeed, float tugDelay, float staminaDecreaseValue)
        {
            if (_tugTimer > tugDelay && _staminaValues.Stamina - staminaDecreaseValue >= 0)
            {
                _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                _tugTimer = 0;
                if ((key1 == KeyCode.A && key2 == KeyCode.W) || (key1 == KeyCode.W && key2 == KeyCode.A))
                {
                    Vector3 targetPosition = new Vector3(characterTransform.position.x - 3,
                        characterTransform.position.y + 3, 0.0f);
                    StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                }
                else if ((key1 == KeyCode.A && key2 == KeyCode.S) || (key1 == KeyCode.S && key2 == KeyCode.A))
                {
                    Vector3 targetPosition = new Vector3(characterTransform.position.x - 3,
                        characterTransform.position.y - 3, 0.0f);
                    StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                }
                else if ((key1 == KeyCode.W && key2 == KeyCode.D) || (key1 == KeyCode.D && key2 == KeyCode.W))
                {
                    Vector3 targetPosition = new Vector3(characterTransform.position.x + 3,
                        characterTransform.position.y + 3, 0.0f);
                    StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                }
                else if ((key1 == KeyCode.D && key2 == KeyCode.S) || (key1 == KeyCode.S && key2 == KeyCode.D))
                {
                    Vector3 targetPosition = new Vector3(characterTransform.position.x + 3,
                        characterTransform.position.y - 3, 0.0f);
                    StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                }
            }
        }

        public void Move(KeyCode key, float movingSpeed, Transform characterTransform, float runSpeed, float staminaDecreaseValue)
        {
            switch(key)
            {
                case KeyCode.W:
                    if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0)
                    {
                        characterTransform.Translate(new Vector3(0.0f, Time.deltaTime * runSpeed, 0.0f));
                        _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                    }
                    else
                        characterTransform.Translate(new Vector3(0.0f, Time.deltaTime * movingSpeed, 0.0f));
                    break;
                case KeyCode.A:
                    if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0)
                    {
                        characterTransform.Translate(new Vector3(-Time.deltaTime * runSpeed, 0.0f, 0.0f));
                        _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                    }
                    else
                        characterTransform.Translate(new Vector3(-Time.deltaTime * movingSpeed, 0.0f, 0.0f));
                    break;
                case KeyCode.S:
                    if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0)
                    {
                        characterTransform.Translate(new Vector3(0.0f, -Time.deltaTime * runSpeed, 0.0f));
                        _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                    }
                    else
                        characterTransform.Translate(new Vector3(0.0f, -Time.deltaTime * movingSpeed, 0.0f));
                    break;
                case KeyCode.D:
                    if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0)
                    {
                        characterTransform.Translate(new Vector3(Time.deltaTime * runSpeed, 0.0f, 0.0f));
                        _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                    }
                    else
                        characterTransform.Translate(new Vector3(Time.deltaTime * movingSpeed, 0.0f, 0.0f));
                    break;
            }
        }

        public void Move(KeyCode key1, KeyCode key2, float movingSpeed, Transform characterTransform, float runSpeed, float staminaDecreaseValue)
        {
            if ((key1 == KeyCode.A && key2 == KeyCode.W) || (key1 == KeyCode.W && key2 == KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0)
                {
                    characterTransform.Translate(new Vector3(-Time.deltaTime * runSpeed, Time.deltaTime * runSpeed,
                        0.0f));
                    _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                }
                else
                    characterTransform.Translate(new Vector3(-Time.deltaTime * movingSpeed,
                        Time.deltaTime * movingSpeed,
                        0.0f));
            }
            else if ((key1 == KeyCode.A && key2 == KeyCode.S) || (key1 == KeyCode.S && key2 == KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0)
                {
                    characterTransform.Translate(new Vector3(-Time.deltaTime * runSpeed, -Time.deltaTime * runSpeed,
                        0.0f));
                    _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                }
                else
                    characterTransform.Translate(new Vector3(-Time.deltaTime * movingSpeed,
                        -Time.deltaTime * movingSpeed,
                        0.0f));
            }
            else if ((key1 == KeyCode.W && key2 == KeyCode.D) || (key1 == KeyCode.D && key2 == KeyCode.W))
            {
                if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0)
                {
                    characterTransform.Translate(new Vector3(Time.deltaTime * runSpeed, Time.deltaTime * runSpeed,
                        0.0f));
                    _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                }
                else
                    characterTransform.Translate(new Vector3(Time.deltaTime * movingSpeed, Time.deltaTime * movingSpeed,
                        0.0f));
            }
            else if ((key1 == KeyCode.D && key2 == KeyCode.S) || (key1 == KeyCode.S && key2 == KeyCode.D))
            {
                if (Input.GetKey(KeyCode.LeftShift) && _staminaValues.Stamina > 0)
                {
                    characterTransform.Translate(new Vector3(Time.deltaTime * runSpeed, -Time.deltaTime * runSpeed,
                        0.0f));
                    _staminaHandler.DecreaseStamina(staminaDecreaseValue);
                }
                else
                    characterTransform.Translate(new Vector3(Time.deltaTime * movingSpeed, -Time.deltaTime * movingSpeed,
                        0.0f));
            }
        }

        public void MakeTug(Transform characterTransform, KeyCode key, float tugSpeed, float tugDelay, float staminaDecreaseValue)
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
                            characterTransform.position.y + 3, 0.0f);
                        StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                        break;
                    case KeyCode.D:
                        targetPosition = new Vector3(characterTransform.position.x + 3,
                            characterTransform.position.y, 0.0f);
                        StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                        break;
                    case KeyCode.S:
                        targetPosition = new Vector3(characterTransform.position.x,
                            characterTransform.position.y - 3, 0.0f);
                        StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                        break;
                    case KeyCode.A:
                        targetPosition = new Vector3(characterTransform.position.x - 3,
                            characterTransform.position.y, 0.0f);
                        StartCoroutine(TugMaker(targetPosition, characterTransform, tugSpeed));
                        break;
                }
            }
        }

        private IEnumerator TugMaker(Vector3 targetPosition, Transform characterTransform, float tugSpeed)
        {
            while (characterTransform.position != targetPosition)
            {
                yield return new WaitForEndOfFrame();
                characterTransform.position =
                    Vector3.MoveTowards(characterTransform.position, targetPosition, Time.deltaTime * tugSpeed);
            }
        }
    }
}