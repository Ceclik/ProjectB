using ComponentScripts.Items;
using Interfaces.CharacterInterfaces.InventoryInterfaces;
using Services.CharacterServices.InventoryScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class ItemsPicker : MonoBehaviour
    {
        private Item _involvedItem;
        private bool _isOnItem;
        private IPutterToInventory _putterToInventory;
        private ActionTextHandler _textHandler;

        private void Start()
        {
            _putterToInventory = new PutterToInventoryService();
            _textHandler = GetComponent<ActionTextHandler>();
        }

        private void Update()
        {
            if (_isOnItem && Input.GetKeyDown(KeyCode.F))
            {
                if (_putterToInventory.PutToInventory(_involvedItem, GetComponent<Inventory>()))
                {
                    Destroy(_involvedItem.gameObject);
                }
                else
                {
                    StartCoroutine(_textHandler.ActionText.ShowActionTextForSomeTime(1.5f, "Інвентар запоўнены!",
                        _textHandler.ActionTextElement));
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item droppedItem))
            {
                _involvedItem = droppedItem;
                _textHandler.ActionText.ShowActionText("Націсніце 'f' каб падабраць прадмет",
                    _textHandler.ActionTextElement);
                _isOnItem = true;
            }
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item droppedItem))
            {
                _involvedItem = null;
                _textHandler.ActionText.HideActionText(_textHandler.ActionTextElement);
                _isOnItem = false;
            }
        }
    }
}