using Services.MovingScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    [RequireComponent(typeof(Character), typeof(CharacterStaminaHandler))]
    public class CharacterMover : MonoBehaviour
    {
        private Character _character;
        private CharacterStaminaHandler _staminaHandler;
        private IPlayerMover _mover;
        private float _movingSpeed;

        [Header("Tug stats")]
        [SerializeField] private float tugSpeed;
        [SerializeField] private float tugDelay;
        [SerializeField] private float tugStaminaDecreaseValue;

        [Space(10)] [Header("Run stats")] [SerializeField]
        private float runSpeed;
        [SerializeField] private float runStaminaDecreasingValuePerSecond;
        
        public void Inject(IPlayerMover mover)
        {
            _mover = mover;
        }
        private void Start()
        {
            _character = GetComponent<Character>();
            _staminaHandler = GetComponent<CharacterStaminaHandler>();
            _movingSpeed = _character.BaseMovingSpeed; //TODO speed counting before invocation move method
        }
        
        private void Update()
        {
            if (Input.anyKey)
            {
                KeyCode keyCode;

                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
                {
                    if(Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, KeyCode.A, KeyCode.W, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(KeyCode.A, KeyCode.W, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerSecond);
                }
                
                else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
                {
                    if(Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, KeyCode.A, KeyCode.S, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(KeyCode.A, KeyCode.S, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerSecond);
                }
                
                else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                {
                    if(Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, KeyCode.W, KeyCode.D, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(KeyCode.W, KeyCode.D, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerSecond);
                }
                
                else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                {
                    if(Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, KeyCode.D, KeyCode.S, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(KeyCode.D, KeyCode.S, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerSecond);
                }
                
                else if (Input.GetKey(KeyCode.A))
                {
                    keyCode = KeyCode.A;
                    if(Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerSecond);
                }

                else if (Input.GetKey(KeyCode.W))
                {
                    keyCode = KeyCode.W;
                    if(Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerSecond);
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    keyCode = KeyCode.S;
                    if(Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerSecond);
                }

                else if (Input.GetKey(KeyCode.D))
                {
                    keyCode = KeyCode.D;
                    if(Input.GetKeyDown(KeyCode.Space))
                        _mover.MakeTug(transform, keyCode, tugSpeed, tugDelay, tugStaminaDecreaseValue);
                    else
                        _mover.Move(keyCode, _movingSpeed, transform, runSpeed, runStaminaDecreasingValuePerSecond);
                }
            }
        }
    }
}