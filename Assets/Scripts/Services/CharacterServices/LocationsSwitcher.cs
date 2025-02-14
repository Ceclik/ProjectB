using UnityEngine;

namespace Services.CharacterServices
{
    public enum Location
    {
        Woods,
        Field
    }

    public class LocationsSwitcher : MonoBehaviour
    {
        private BackgroundColorSwitcher _colorSwitcher;
        public Location location { get; private set; }

        private void Start()
        {
            _colorSwitcher = GameObject.Find("Background").GetComponent<BackgroundColorSwitcher>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Woods"))
                location = Location.Woods;
            else if (other.CompareTag("Field"))
                location = Location.Field;

            _colorSwitcher.ChangeBackgroundColor(location);
        }
    }
}