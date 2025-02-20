using Interfaces.CharacterInterfaces.UIInterfaces;
using Services.CharacterServices.UIScripts;
using TMPro;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class ActionTextHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI actionText;

        public TextMeshProUGUI ActionTextElement => actionText;
        public IActionTextHandler ActionText { get; private set; }

        private void Start()
        {
            actionText.gameObject.SetActive(false);
            ActionText = new ActionTextHandlerService();
        }
    }
}