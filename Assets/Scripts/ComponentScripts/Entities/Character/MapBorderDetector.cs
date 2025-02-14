using TMPro;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class MapBorderDetector : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI actionText;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("SwampBorder"))
            {
                actionText.gameObject.SetActive(true);
                actionText.text = "Далей ідуць непраходныя палесскія балоты! Праз іх не прабрацца!";
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("SwampBorder")) actionText.gameObject.SetActive(false);
        }
    }
}