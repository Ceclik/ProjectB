using UnityEngine;

namespace ComponentScripts.Entities.Enemies
{
    public abstract class Enemy : ActiveEntity
    {
        public Transform Nest { get; set; }
        public int CurrentPointIndex { get; set; }
        protected int ReceivingExperience;
        //TODO receivingItems
    }
}