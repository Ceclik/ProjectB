using DataClasses;
using UnityEngine;

namespace ComponentScripts
{
    public class ItemsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject potato;
        [SerializeField] private GameObject meat;

        public GameObject GetItemPrefab(ItemData requiredItem)
        {
            switch (requiredItem.Name)
            {
                case "Potato": return potato;
                case "Meat": return meat;
            }

            return null;
        }
    }
}