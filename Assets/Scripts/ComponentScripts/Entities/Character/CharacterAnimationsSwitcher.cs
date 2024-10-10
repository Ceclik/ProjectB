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

            _mover.OnStop += SetFrontIdleAnimation;
            _mover.OnSideWalkStart += SetSideWalkAnimation;
            _mover.OnFrontWalkStart += SetFrontWalkAnimation;
            _mover.OnStopBackIdle += SetBackIdleAnimation;
        }

        private void SetBackIdleAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("BackIdle");
        }

        private void SetSideWalkAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("SideWalk");
        }

        private void SetFrontWalkAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("FrontWalk");
        }

        private void SetFrontIdleAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("FrontIdle");
        }

        private void ResetAllTriggers()
        {
            _animator.ResetTrigger("FrontIdle");
            _animator.ResetTrigger("FrontWalk");
            _animator.ResetTrigger("SideWalk");
            _animator.ResetTrigger("BackIdle");
        }

        private void OnDestroy()
        {
            _mover.OnStopBackIdle -= SetBackIdleAnimation;
            _mover.OnStop -= SetFrontIdleAnimation;
            _mover.OnSideWalkStart -= SetSideWalkAnimation;
            _mover.OnFrontWalkStart -= SetFrontWalkAnimation;
        }
    }
}