using UnityEngine;

namespace ComponentScripts.Entities.Enemies
{
    public class EnemyAnimationsHandler : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            Debug.Log($"Animator: {_animator}");
        }

        private void ResetAllTriggers()
        {
            _animator.ResetTrigger("Move");
            _animator.ResetTrigger("Stop");
        }

        public void TurnMoveAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("Move");
        }

        public void TurnStayAnimation()
        {
            ResetAllTriggers();
            _animator.SetTrigger("Stop");
        }
    }
}