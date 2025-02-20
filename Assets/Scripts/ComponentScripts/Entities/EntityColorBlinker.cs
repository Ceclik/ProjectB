using System.Collections;
using UnityEngine;

namespace ComponentScripts.Entities
{
    public class EntityColorBlinker : MonoBehaviour
    {
        [SerializeField] private Color targetColor;
        [SerializeField] private float blinkDuration = 0.2f;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public IEnumerator Blink()
        {
            _spriteRenderer.color = targetColor;
            yield return new WaitForSeconds(blinkDuration);
            _spriteRenderer.color = Color.white;
        }
    }
}