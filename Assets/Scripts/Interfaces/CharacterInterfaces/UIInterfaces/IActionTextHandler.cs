using System.Collections;
using TMPro;

namespace Interfaces.CharacterInterfaces.UIInterfaces
{
    public interface IActionTextHandler
    {
        public void ShowActionText(string text, TextMeshProUGUI textElement);
        public void HideActionText(TextMeshProUGUI textElement);
        public IEnumerator ShowActionTextForSomeTime(float time, string text, TextMeshProUGUI textElement);
    }
}