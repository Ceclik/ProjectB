using UnityEngine;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class InventoryOpener : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryBackground;

        public GameObject Inventory => inventoryBackground;
        

        private void Start()
        {
            inventoryBackground.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && !inventoryBackground.activeSelf)
                inventoryBackground.SetActive(true);
            else if((Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.Escape)) && inventoryBackground.activeSelf)
                inventoryBackground.SetActive(false);
        }
    }
}