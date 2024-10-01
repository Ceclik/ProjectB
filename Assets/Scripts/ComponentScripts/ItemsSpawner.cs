using DataClasses;
using UnityEngine;

namespace ComponentScripts
{
    public class ItemsSpawner : MonoBehaviour
    {
        [Header("Food")]
        [SerializeField] private GameObject potato;
        [SerializeField] private GameObject meat;

        [Space(15)] [Header("Weapons")] [SerializeField]
        private GameObject axe;

        public GameObject GetItemPrefab(ItemData requiredItem)
        {
            switch (requiredItem.Name)
            {
                case "Potato": return potato;
                case "Meat": return meat;
                case "Axe": return axe;
            }

            return null;
        }
    }
}