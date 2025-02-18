using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class InventoryOpener : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryBackground;

        public GameObject Inventory => inventoryBackground;
        //private IInventoryUIHandler _uiHandler;


        private void Start()
        {
            inventoryBackground.SetActive(false);
            //_uiHandler = new InventoryUIHandlerService();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && !inventoryBackground.activeSelf)
            {
                inventoryBackground.SetActive(true);
                //_uiHandler.UpdateUI(inventory, Panels);
                
            }
            else if ((Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.Escape)) && inventoryBackground.activeSelf)
                inventoryBackground.SetActive(false);
        }
    }
}