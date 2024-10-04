using System.Collections.Generic;
using ComponentScripts.Items;
using DataClasses;
using UnityEngine;

namespace ComponentScripts.Entities.ResourceObjects
{
    public class ResourceObject : Entity
    {
        public ItemData[] DroppingItems { get; protected set; }
        
        [SerializeField] private List<GameObject> droppingItems;
        private void Awake()
        {
            DroppingItems = new ItemData[droppingItems.Count];
            for (int i = 0; i < droppingItems.Count; i++)
            { 
                DroppingItems[i] = new ItemData(droppingItems[i].GetComponent<Item>());
            }
        }
        
    }
}