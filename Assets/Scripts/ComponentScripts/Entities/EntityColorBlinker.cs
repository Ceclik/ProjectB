using System.Collections;
using UnityEngine;

namespace ComponentScripts.Entities
{
    public class EntityColorBlinker : MonoBehaviour
    {
        [SerializeField] private Color targetColor;
        [SerializeField] private float blinkDuration = 0.2f;
        private Color _originalColor;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public IEnumerator Blink()
        {
            _originalColor = _spriteRenderer.color;
            _spriteRenderer.color = targetColor;
            yield return new WaitForSeconds(blinkDuration);
            _spriteRenderer.color = _originalColor;
        }
    }
}