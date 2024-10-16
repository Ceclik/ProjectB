using System;
using ComponentScripts.Entities.Character.InventoryScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class ArmorHandler : MonoBehaviour
    {
        private Inventory _inventory;
        public bool IsUsingSchield { get; private set; }

        private void Start()
        {
            _inventory = GetComponent<Inventory>();
        }

        private void Update()
        {
            if (!IsUsingSchield && _inventory.SecondHand.Name == "Shield" && Input.GetKeyDown(KeyCode.Mouse1))
            {
                IsUsingSchield = true;
            }
        }
    }
}