using DataClasses;
using Interfaces;
using UnityEngine;

namespace ComponentScripts
{
    public abstract class ActiveEntity : Entity
    {
        [SerializeField] protected float baseMovingSpeed;
        [SerializeField] protected int baseDamage;
        protected IDamageReceiver _damageReceiver;

        public float BaseMovingSpeed => baseMovingSpeed;
    }
}