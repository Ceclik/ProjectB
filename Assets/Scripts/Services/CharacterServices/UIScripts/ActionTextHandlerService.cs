using TMPro;

namespace Services.CharacterServices.UIScripts
{
    public class ActionTextHandlerService : IActionTextHandler
    {
        public void ShowActionText(string text, TextMeshProUGUI textElement)
        {
            textElement.gameObject.SetActive(true);
            textElement.text = text;
        }

        public void HideActionText(TextMeshProUGUI textElement)
        {
            textElement.gameObject.SetActive(false);
        }
    }
}