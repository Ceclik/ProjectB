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
        private CharacterStaminaHandler _staminaHandler;

        private void Start()
        {
            _character = GetComponent<Character>();
            _staminaHandler = GetComponent<CharacterStaminaHandler>();
            _movingSpeed = _character.BaseMovingSpeed; //TODO speed counting before invocation move method
            _inventory = GetComponent<InventoryOpener>();
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
                        _mover.Move(KeyCode.A, KeyCode.W, _movingSpeed, transform, runSpeed,
                            runStaminaDecreasingValuePerFrame);
                }

                else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, KeyCode.A, KeyCode.S, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(KeyCode.A, KeyCode.S, _movingSpeed, transform, runSpeed,
                            runStaminaDecreasingValuePerFrame);
                }

                else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, KeyCode.W, KeyCode.D, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(KeyCode.W, KeyCode.D, _movingSpeed, transform, runSpeed,
                            runStaminaDecreasingValuePerFrame);
                }

                else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, KeyCode.D, KeyCode.S, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(KeyCode.D, KeyCode.S, _movingSpeed, transform, runSpeed,
                            runStaminaDecreasingValuePerFrame);
                }

                else if (Input.GetKey(KeyCode.A))
                {
                    keyCode = KeyCode.A;
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);
                }

                else if (Input.GetKey(KeyCode.W))
                {
                    keyCode = KeyCode.W;
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    keyCode = KeyCode.S;
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);
                }

                else if (Input.GetKey(KeyCode.D))
                {
                    keyCode = KeyCode.D;
                    if (Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerFrame);
                }
            }
        }

        public void Inject(IPlayerMover mover)
        {
            _mover = mover;
        }
    }
}