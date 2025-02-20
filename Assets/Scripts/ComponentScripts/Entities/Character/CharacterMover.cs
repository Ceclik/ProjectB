using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using Interfaces.CharacterInterfaces.MovingInterfaces;
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
        private CharacterAnimationsSwitcher _animationSwitcher;
        private ArmorHandler _armorHandler;
        private Character _character;
        private Inventory _inventory;
        private InventoryOpener _inventoryOpener;

        private bool _isCharacterFlipped;
        private IPlayerMover _mover;
        private float _movingSpeed;
        private Rigidbody2D _rigidbody;
        private ShelterHider _shelterHider;
        public bool IsMoving { get; private set; }

        private void Awake()
        {
            _mover = gameObject.AddComponent<PlayerMoverService>();
        }

        private void Start()
        {
            _armorHandler = GetComponent<ArmorHandler>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _animationSwitcher = GetComponent<CharacterAnimationsSwitcher>();
            _character = GetComponent<Character>();
            _movingSpeed = _character.BaseMovingSpeed; //TODO speed counting before invocation move method
            _inventoryOpener = GetComponent<InventoryOpener>();
            _shelterHider = GetComponent<ShelterHider>();
            _inventory = GetComponent<Inventory>();
        }

        private void Update()
        {
            CountMovingSpeed();
            if (!_shelterHider.IsInShelter)
                if (Input.anyKey && !_inventoryOpener.Inventory.activeSelf)
                {
                    KeyCode keyCode;

                    if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
                    {
                        if (Input.GetKeyDown(KeyCode.Space) && !_armorHandler.IsUsingShield)
                        {
                            _mover.MakeTug(transform, KeyCode.A, KeyCode.W, tugSpeed, tugDelay,
                                tugStaminaDecreaseValue);
                        }
                        else
                        {
                            _mover.Move(KeyCode.A, KeyCode.W, _movingSpeed, transform, runSpeed,
                                runStaminaDecreasingValuePerFrame);

                            if (!_isCharacterFlipped)
                            {
                                FlipCharacterHorizontal();
                                _isCharacterFlipped = true;
                            }

                            _animationSwitcher.SetSideWalkAnimation();
                            IsMoving = true;
                        }
                    }

                    else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
                    {
                        if (Input.GetKeyDown(KeyCode.Space) && !_armorHandler.IsUsingShield)
                        {
                            _mover.MakeTug(transform, KeyCode.A, KeyCode.S, tugSpeed, tugDelay,
                                tugStaminaDecreaseValue);
                        }
                        else
                        {
                            _mover.Move(KeyCode.A, KeyCode.S, _movingSpeed, transform, runSpeed,
                                runStaminaDecreasingValuePerFrame);

                            if (!_isCharacterFlipped)
                            {
                                FlipCharacterHorizontal();
                                _isCharacterFlipped = true;
                            }

                            _animationSwitcher.SetSideWalkAnimation();
                            IsMoving = true;
                        }
                    }

                    else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                    {
                        if (Input.GetKeyDown(KeyCode.Space) && !_armorHandler.IsUsingShield)
                        {
                            _mover.MakeTug(transform, KeyCode.W, KeyCode.D, tugSpeed, tugDelay,
                                tugStaminaDecreaseValue);
                        }
                        else
                        {
                            _mover.Move(KeyCode.W, KeyCode.D, _movingSpeed, transform, runSpeed,
                                runStaminaDecreasingValuePerFrame);
                            _animationSwitcher.SetSideWalkAnimation();
                            IsMoving = true;
                        }
                    }

                    else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                    {
                        if (Input.GetKeyDown(KeyCode.Space) && !_armorHandler.IsUsingShield)
                        {
                            _mover.MakeTug(transform, KeyCode.D, KeyCode.S, tugSpeed, tugDelay,
                                tugStaminaDecreaseValue);
                        }
                        else
                        {
                            _mover.Move(KeyCode.D, KeyCode.S, _movingSpeed, transform, runSpeed,
                                runStaminaDecreasingValuePerFrame);
                            _animationSwitcher.SetSideWalkAnimation();
                            IsMoving = true;
                        }
                    }

                    else if (Input.GetKey(KeyCode.A))
                    {
                        keyCode = KeyCode.A;
                        if (Input.GetKeyDown(KeyCode.Space) && !_armorHandler.IsUsingShield)
                        {
                            _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                        }
                        else
                        {
                            _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);

                            if (!_isCharacterFlipped)
                            {
                                FlipCharacterHorizontal();
                                _isCharacterFlipped = true;
                            }

                            _animationSwitcher.SetSideWalkAnimation();
                            IsMoving = true;
                        }
                    }

                    else if (Input.GetKey(KeyCode.W))
                    {
                        keyCode = KeyCode.W;
                        if (Input.GetKeyDown(KeyCode.Space) && !_armorHandler.IsUsingShield)
                        {
                            _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                        }
                        else
                        {
                            _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);
                            _animationSwitcher.SetBackWalkAnimation();
                            IsMoving = true;
                        }
                    }

                    else if (Input.GetKey(KeyCode.S))
                    {
                        keyCode = KeyCode.S;
                        if (Input.GetKeyDown(KeyCode.Space) && !_armorHandler.IsUsingShield)
                        {
                            _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                        }
                        else
                        {
                            _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);
                            if (Input.GetKey(KeyCode.Mouse1) && _inventory.SecondHand.Value is ShieldData)
                                _animationSwitcher.SetFrontWalkShieldAnimation();
                            else
                                _animationSwitcher.SetFrontWalkAnimation();
                            IsMoving = true;
                        }
                    }

                    else if (Input.GetKey(KeyCode.D))
                    {
                        keyCode = KeyCode.D;
                        if (Input.GetKeyDown(KeyCode.Space) && !_armorHandler.IsUsingShield)
                        {
                            _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                        }
                        else
                        {
                            _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);
                            _animationSwitcher.SetSideWalkAnimation();
                            IsMoving = true;
                        }
                    }
                }
        }

        private void LateUpdate()
        {
            SetIdleAnimation();
        }

        private void CountMovingSpeed()
        {
            _movingSpeed = _character.BaseMovingSpeed;
            if (_armorHandler.IsUsingShield)
                _movingSpeed *= (100 - _armorHandler.ActualShield.PercentOfSlowingCharacter) / 100;
        }

        private void SetIdleAnimation()
        {
            if (Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.W))
            {
                if (_isCharacterFlipped)
                {
                    FlipCharacterHorizontal();
                    _isCharacterFlipped = false;
                }

                _animationSwitcher.SetBackIdleAnimation();
            }

            else if (Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.S))
            {
                if (_isCharacterFlipped)
                {
                    FlipCharacterHorizontal();
                    _isCharacterFlipped = false;
                }

                _animationSwitcher.SetFrontIdleAnimation();
            }

            else if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.D))
            {
                _animationSwitcher.SetBackIdleAnimation();
            }

            else if (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.S))
            {
                _animationSwitcher.SetFrontIdleAnimation();
            }

            else if (Input.GetKeyUp(KeyCode.A))
            {
                if (_isCharacterFlipped)
                {
                    FlipCharacterHorizontal();
                    _isCharacterFlipped = false;
                }

                _animationSwitcher.SetFrontIdleAnimation();
            }

            else if (Input.GetKeyUp(KeyCode.W))
            {
                _animationSwitcher.SetBackIdleAnimation();
            }

            else if (Input.GetKeyUp(KeyCode.S))
            {
                _animationSwitcher.SetFrontIdleAnimation();
            }

            else if (Input.GetKeyUp(KeyCode.D))
            {
                _animationSwitcher.SetFrontIdleAnimation();
            }

            _rigidbody.linearVelocity = Vector2.zero;
            IsMoving = false;
        }

        private void FlipCharacterHorizontal()
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
        }
    }
}