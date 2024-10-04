using System.Collections.Generic;
using ComponentScripts.Items;
using DataClasses;
using UnityEngine;

namespace ComponentScripts.Entities.ResourceObjects
{
    public class Tree : ResourceObject
    {
        [SerializeField] private List<GameObject> droppingItems;
        private void Awake()
        {
            DroppingItems = new ItemData[droppingItems.Count];
            for (int i = 0; i < droppingItems.Count; i++)
            { 
                Debug.Log($"Tree dropping item is: {droppingItems[i].GetComponent<Item>().Name}");
                DroppingItems[i] = new ItemData(droppingItems[i].GetComponent<Item>());
                
            }
        }
    }
}