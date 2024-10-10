using ComponentScripts.Entities.Character.InventoryScripts;
using Services.CharacterServices.MovingScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    [RequireComponent(typeof(Character), typeof(CharacterStaminaHandler))]
    public class CharacterMover : MonoBehaviour
    {
        [Header("Tug stats")] [SerializeField] private float tugSpeed;

        [SerializeField] private float tugDelay;
        [SerializeField] private float tugStaminaDecreaseValue;

        [Space(10)] [Header("Run stats")] [SerializeField]
        private float runSpeed;

        [SerializeField] private float runStaminaDecreasingValuePerFrame;
        private Character _character;
        private InventoryOpener _inventory;
        private IPlayerMover _mover;
        private float _movingSpeed;

        private bool _isCharacterFlipped;

        public delegate void SwitchAnimatorTrigger();

        public event SwitchAnimatorTrigger OnSideWalkStart;

        public event SwitchAnimatorTrigger OnFrontWalkStart;
        public event SwitchAnimatorTrigger OnStopBackIdle;
        public event SwitchAnimatorTrigger OnStop;

        private void Start()
        {
            _character = GetComponent<Character>();
            _movingSpeed = _character.BaseMovingSpeed; //TODO speed counting before invocation move method
            _inventory = GetComponent<InventoryOpener>();
        }

        private void InvokeIdleEvent()
        {
            if (Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.W))
            {
                
                if (_isCharacterFlipped)
                {
                    FlipCharacterHorizontal();
                    _isCharacterFlipped = false;
                }

                OnStopBackIdle?.Invoke();
            }
            
            else if (Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.S))
            {
                if (_isCharacterFlipped)
                {
                    FlipCharacterHorizontal();
                    _isCharacterFlipped = false;
                }
                OnStop?.Invoke();
            }
            
            else if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.D))
            {
                OnStopBackIdle?.Invoke();
            }
            
            else if (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.S))
            {
                OnStop?.Invoke();
            }
            
            else if (Input.GetKeyUp(KeyCode.A))
            {
                if (_isCharacterFlipped)
                {
                    FlipCharacterHorizontal();
                    _isCharacterFlipped = false;
                }
                OnStop?.Invoke();
            }
            
            else if (Input.GetKeyUp(KeyCode.W))
            {
                OnStopBackIdle?.Invoke();
            }
            
            else if (Input.GetKeyUp(KeyCode.S))
            {
                OnStop?.Invoke();
            }
            
            else if (Input.GetKeyUp(KeyCode.D))
            {
                OnStop?.Invoke();
            }
        }

        private void FlipCharacterHorizontal()
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1); 
        }

        private void Update()
        {
            InvokeIdleEvent();
        }

        private void FixedUpdate()
        {
            if (Input.anyKey && !_inventory.Inventory.activeSelf)
            {
                KeyCode keyCode;

                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, KeyCode.A, KeyCode.W, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                    {
                        _mover.Move(KeyCode.A, KeyCode.W, _movingSpeed, transform, runSpeed,
                            runStaminaDecreasingValuePerFrame);
                        
                        if (!_isCharacterFlipped)
                        {
                            FlipCharacterHorizontal();
                            _isCharacterFlipped = true;
                        }
                        
                        OnSideWalkStart?.Invoke();
                    }
                }
                
                else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, KeyCode.A, KeyCode.S, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                    {
                        _mover.Move(KeyCode.A, KeyCode.S, _movingSpeed, transform, runSpeed,
                            runStaminaDecreasingValuePerFrame);
                        
                        if (!_isCharacterFlipped)
                        {
                            FlipCharacterHorizontal();
                            _isCharacterFlipped = true;
                        }

                        OnSideWalkStart?.Invoke();
                    }
                }
                
                else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, KeyCode.W, KeyCode.D, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                    {
                        _mover.Move(KeyCode.W, KeyCode.D, _movingSpeed, transform, runSpeed,
                            runStaminaDecreasingValuePerFrame);
                        OnSideWalkStart?.Invoke();
                    }
                }

                else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, KeyCode.D, KeyCode.S, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                    {
                        _mover.Move(KeyCode.D, KeyCode.S, _movingSpeed, transform, runSpeed,
                            runStaminaDecreasingValuePerFrame);
                        OnSideWalkStart?.Invoke();
                    }
                }

                else if (Input.GetKey(KeyCode.A))
                {
                    keyCode = KeyCode.A;
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                    {
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);
                        
                        if (!_isCharacterFlipped)
                        {
                            FlipCharacterHorizontal();
                            _isCharacterFlipped = true;
                        }

                        OnSideWalkStart?.Invoke();
                    }
                }

                else if (Input.GetKey(KeyCode.W))
                {
                    keyCode = KeyCode.W;
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                    {
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);
                        OnFrontWalkStart?.Invoke();
                    }
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    keyCode = KeyCode.S;
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                    {
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);
                        OnFrontWalkStart?.Invoke();
                    }
                }

                else if (Input.GetKey(KeyCode.D))
                {
                    keyCode = KeyCode.D;
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                    {
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);
                        OnSideWalkStart?.Invoke();
                    }
                }
            }
        }

        public void Inject(IPlayerMover mover)
        {
            _mover = mover;
        }
    }
}