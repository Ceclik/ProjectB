using System;
using System.Collections;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class ShelterHider : MonoBehaviour
    {
        [SerializeField] private float nextHidingDelayTime;
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider;
        private float _nextHidingTimer;
        public bool IsInShelter { get; private set; }

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
            _nextHidingTimer = nextHidingDelayTime + 1;
        }

        private void Update()
        {
            if(_nextHidingTimer < nextHidingDelayTime + 1 && !IsInShelter)
                _nextHidingTimer += Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Shelter shelter) && _nextHidingTimer > nextHidingDelayTime)
            {
                IsInShelter = true;
                _spriteRenderer.enabled = false;
                _collider.enabled = false;
                StartCoroutine(DisableHidedState(shelter.HidingTime));
            }
        }

        private IEnumerator DisableHidedState(float delay)
        {
            yield return new WaitForSeconds(delay);
            _spriteRenderer.enabled = true;
            _collider.enabled = true;
            IsInShelter = false;
            _nextHidingTimer = 0;
        }
    }
}