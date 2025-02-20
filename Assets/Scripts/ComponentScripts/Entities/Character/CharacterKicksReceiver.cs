using ComponentScripts.Entities.Enemies;
using Interfaces.CharacterInterfaces.MovingInterfaces;
using Services.CharacterServices.MovingScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class CharacterKicksReceiver : MonoBehaviour
    {
        [SerializeField] private float knockBackForce = 1.0f;
        [SerializeField] private float knockBackDuration = 0.3f;
        private EntityColorBlinker _colorBlinker;
        private IPlayerMover _mover;

        private void Start()
        {
            _mover = GetComponent<PlayerMoverService>();
            _colorBlinker = GetComponent<EntityColorBlinker>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Enemy enemy))
            {
                Vector2 knockBackDirection = (transform.position - enemy.transform.position).normalized;
                _mover.ApplyKnockBack(knockBackDirection, knockBackForce, knockBackDuration);
                StartCoroutine(_colorBlinker.Blink());
                Debug.DrawLine(transform.position, transform.position + (Vector3)knockBackDirection * 5, Color.red, 2f);
            }
        }
    }
}