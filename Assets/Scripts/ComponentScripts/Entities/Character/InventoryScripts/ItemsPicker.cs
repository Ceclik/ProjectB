using ComponentScripts.Items;
using Services.CharacterServices.InventoryScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class ItemsPicker : MonoBehaviour
    {
        private ActionTextHandler _textHandler;
        private IPutterToInventory _putterToInventory;
        
        public void Inject(IPutterToInventory putterToInventory)
        {
            _putterToInventory = putterToInventory;
        }

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

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item droppedItem) && Input.GetKeyDown(KeyCode.F))
            {
                _putterToInventory.PutToInventory(droppedItem, GetComponent<Inventory>());
                Destroy(droppedItem.gameObject);
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