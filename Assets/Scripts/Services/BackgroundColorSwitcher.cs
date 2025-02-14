using Services.CharacterServices;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public class BackgroundColorSwitcher : MonoBehaviour
    {
        [SerializeField] private Color woodsBackgroundColor;
        [SerializeField] private Color fieldBackgroundColor;

        [Space(10)] [SerializeField] private float transitionDuration;
        private Image _currentColor;
        private float _elapsedTime;

        private bool _isChanging;
        private Color _newColor;

        private void Start()
        {
            _currentColor = GetComponent<Image>();
        }

        private void Update()
        {
            if (_isChanging)
            {
                _elapsedTime += Time.deltaTime;
                _currentColor.color = Color.Lerp(_currentColor.color, _newColor, _elapsedTime / transitionDuration);
                if (_elapsedTime >= transitionDuration) _isChanging = false;
            }
        }

        public void ChangeBackgroundColor(Location location)
        {
            Debug.Log($"In change color!, location: {location}");
            _newColor = location == Location.Woods ? woodsBackgroundColor : fieldBackgroundColor;
            _isChanging = true;
            _elapsedTime = 0;
        }
    }
}