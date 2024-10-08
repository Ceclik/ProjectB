using System;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class CharacterAnimationsSwitcher : MonoBehaviour
    {
        private Animator _animator;
        private CharacterMover _mover;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _mover = GetComponent<CharacterMover>();

            _mover.OnStop += SetIdleAnimation;
            _mover.OnWalkStart += SetWalkAnimation;
        }

        private void SetWalkAnimation()
        {
            //_animator.ResetTrigger("Run");
            _animator.ResetTrigger("Idle");
            _animator.SetTrigger("Walk");
        }

        private void SetIdleAnimation()
        {
            Debug.Log("In set idle animation");
            _animator.ResetTrigger("Walk");
            //_animator.ResetTrigger("Run");
            _animator.SetTrigger("Idle");
        }

        private void OnDestroy()
        {
            _mover.OnStop -= SetIdleAnimation;
            _mover.OnWalkStart -= SetWalkAnimation;
        }
    }
}