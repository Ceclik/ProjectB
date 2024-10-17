using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class CharacterAnimationsSwitcher : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetBackIdleAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("BackIdle");
        }

        public void SetSideWalkAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("SideWalk");
        }

        public void SetFrontWalkAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("FrontWalk");
        }

        public void SetFrontIdleAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("FrontIdle");
        }

        public void SetBackWalkAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("BackWalk");
        }

        public void SetIdleShieldAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("IdleShield");
        }

        private void ResetAllTriggers()
        {
            _animator.ResetTrigger("BackWalk");
            _animator.ResetTrigger("FrontIdle");
            _animator.ResetTrigger("FrontWalk");
            _animator.ResetTrigger("SideWalk");
            _animator.ResetTrigger("BackIdle");
            _animator.ResetTrigger("IdleShield");
        }
    }
}