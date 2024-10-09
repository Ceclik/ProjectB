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
            _mover.OnSideWalkStart += SetSideWalkAnimation;
            _mover.OnFrontWalkStart += SetFrontWalkAnimation;
        }

        private void SetSideWalkAnimation()
        {
            //_animator.ResetTrigger("Run");
            _animator.ResetTrigger("Idle");
            _animator.ResetTrigger("FrontWalk");
            _animator.SetTrigger("SideWalk");
        }

        private void SetFrontWalkAnimation()
        {
            //_animator.ResetTrigger("Run");
            _animator.ResetTrigger("Idle");
            _animator.ResetTrigger("SideWalk");
            _animator.SetTrigger("FrontWalk");
        }

        private void SetIdleAnimation()
        {
            Debug.Log("In set idle animation");
            _animator.ResetTrigger("SideWalk");
            //_animator.ResetTrigger("Run");
            _animator.ResetTrigger("FrontWalk");
            _animator.SetTrigger("Idle");
        }

        private void OnDestroy()
        {
            _mover.OnStop -= SetIdleAnimation;
            _mover.OnSideWalkStart -= SetSideWalkAnimation;
            _mover.OnFrontWalkStart -= SetFrontWalkAnimation;
        }
    }
}