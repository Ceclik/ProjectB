using System.Collections;
using Interfaces.CharacterInterfaces.UIInterfaces;
using TMPro;
using UnityEngine;

namespace Services.CharacterServices.UIScripts
{
    public class ActionTextHandlerService : IActionTextHandler
    {
        public void ShowActionText(string text, TextMeshProUGUI textElement)
        {
            if (textElement != null)
            {
                textElement.gameObject.SetActive(true);
                textElement.text = text;
            }
        }
        
        public void HideActionText(TextMeshProUGUI textElement)
        {
            if (textElement != null)
            {
                textElement.color = Color.white;
                textElement.gameObject.SetActive(false);
            }
        }

        public IEnumerator ShowActionTextForSomeTime(float time, string text, TextMeshProUGUI textElement)
        {
            ShowActionText(text, textElement);
            textElement.color = Color.red;
            yield return new WaitForSeconds(time);
            HideActionText(textElement);
        }
    }
}