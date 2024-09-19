using ComponentScripts.Items;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class ItemsPicker : MonoBehaviour
    {
        private ActionTextHandler _textHandler;

        private void Start()
        {
            _textHandler = GetComponent<ActionTextHandler>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item droppedItem))
            {
                _textHandler.ActionText.ShowActionText("Press 'f' to pick object", _textHandler.ActionTextElement);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item droppedItem))
            {
                _textHandler.ActionText.HideActionText(_textHandler.ActionTextElement);
            }
        }
    }
}