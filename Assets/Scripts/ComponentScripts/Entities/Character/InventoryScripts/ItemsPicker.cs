using ComponentScripts.Items;
using Services.CharacterServices.InventoryScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class ItemsPicker : MonoBehaviour
    {
        private Item _involvedItem;
        private IPutterToInventory _putterToInventory;
        private ActionTextHandler _textHandler;

        private void Start()
        {
            _textHandler = GetComponent<ActionTextHandler>();
        }

        private void Update()
        {
            if (_textHandler.ActionTextElement.IsActive() && Input.GetKeyDown(KeyCode.F))
            {
                _putterToInventory.PutToInventory(_involvedItem, GetComponent<Inventory>());
                Destroy(_involvedItem.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item droppedItem))
            {
                _involvedItem = droppedItem;
                _textHandler.ActionText.ShowActionText("Press 'f' to pick object", _textHandler.ActionTextElement);
            }
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item droppedItem))
            {
                _involvedItem = null;
                _textHandler.ActionText.HideActionText(_textHandler.ActionTextElement);
            }
        }

        public void Inject(IPutterToInventory putterToInventory)
        {
            _putterToInventory = putterToInventory;
        }
    }
}