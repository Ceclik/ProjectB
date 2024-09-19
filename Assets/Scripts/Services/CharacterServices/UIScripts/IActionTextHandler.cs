using TMPro;

namespace Services.CharacterServices.UIScripts
{
    public interface IActionTextHandler
    {
        public void ShowActionText(string text, TextMeshProUGUI textElement);
        public void HideActionText(TextMeshProUGUI textElement);
    }
}