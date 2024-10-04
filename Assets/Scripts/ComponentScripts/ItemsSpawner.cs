using DataClasses;
using UnityEngine;

namespace ComponentScripts
{
    public class ItemsSpawner : MonoBehaviour
    {
        [Header("Food")]
        [SerializeField] private GameObject potato;
        [SerializeField] private GameObject meat;

        [Space(15)] [Header("Tools")] [SerializeField]
        private GameObject axe;
        [SerializeField] private GameObject pickaxe;

        [Space(15)] [Header("Ingredients")] [SerializeField]
        private GameObject wood;
        [SerializeField] private GameObject rockItem;

        public GameObject GetItemPrefab(ItemData requiredItem)
        {
            switch (requiredItem.Name)
            {
                case "Potato": return potato;
                case "Meat": return meat;
                case "Axe": return axe;
                case "Wood": return wood;
                case "RockItem": return rockItem;
                case "Pickaxe": return pickaxe;
            }

            return null;
        }
    }
}