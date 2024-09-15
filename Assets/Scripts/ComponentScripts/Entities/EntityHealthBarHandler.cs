using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Entities
{
    public class EntityHealthBarHandler : MonoBehaviour
    {
        [SerializeField] private Image healthBarBackground;
        [SerializeField] private Image healthBar;
        [SerializeField] private float healthBarFadeDelay;
        [SerializeField] private float healthBarFadeDuration;

        private float _fadeTimer;
        private float _fadingTimer;
        
        private Color _finishImageColor;
        private Color _finishBackgroundColor;
        private Color _normalImageColor;
        private Color _normalBackgroundColor;

        private void Start()
        {
            healthBarBackground.gameObject.SetActive(false);
            
            _finishImageColor = new Color(healthBar.color.r, healthBar.color.g, healthBar.color.b, 0.0f);
            _finishBackgroundColor = new Color(healthBarBackground.color.r, healthBarBackground.color.g,
                healthBarBackground.color.b, 0.0f);

            _normalImageColor = healthBar.color;
            _normalBackgroundColor = healthBarBackground.color;
        }

        private void Update()
        {
            if (healthBarBackground.gameObject.activeSelf)
                _fadeTimer += Time.deltaTime;

            if (healthBarBackground.gameObject.activeSelf && _fadeTimer > healthBarFadeDelay)
            {
                _fadingTimer += Time.deltaTime;

                float fadingProgress = Mathf.Clamp01(_fadingTimer / healthBarFadeDuration);

                healthBar.color = Color.Lerp(_normalImageColor, _finishImageColor, fadingProgress);
                healthBarBackground.color =
                    Color.Lerp(_normalBackgroundColor, _finishBackgroundColor, fadingProgress);

                if (fadingProgress >= 1.0f)
                {
                    _fadeTimer = 0;
                    _fadingTimer = 0;
                    healthBarBackground.gameObject.SetActive(false);
                }
            }

            /*if (healthBarBackground.gameObject.activeSelf && fade)
            {
                _fadeTimer = 0;
                _fadingTimer = 0;
                healthBarBackground.gameObject.SetActive(false);
            }*/
        }

        public void UpdateHealthBar(Entity selfEntity)
        {
            healthBarBackground.gameObject.SetActive(true);
            healthBarBackground.color = _normalBackgroundColor;
            healthBar.color = _normalImageColor;
            healthBar.fillAmount =
                (float)selfEntity.ActualHealth * 100 / selfEntity.BaseHealth / 100;
        }

       
    }
}