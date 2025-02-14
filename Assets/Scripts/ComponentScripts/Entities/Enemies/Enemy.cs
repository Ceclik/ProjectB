using UnityEngine;

namespace ComponentScripts.Entities.Enemies
{
    public abstract class Enemy : ActiveEntity
    {
        protected int ReceivingExperience;
        public Transform Nest { get; set; }
        public bool IsFollowing { get; set; }
        public bool IsMoving { get; set; }

        public bool IsStaying { get; set; }
        //TODO receivingItems
    }
}