using UnityEngine;

namespace ComponentScripts
{
    public abstract class ActiveEntity : Entity
    {
        [SerializeField] protected float baseMovingSpeed;
        [SerializeField] protected int baseDamage;

        public float BaseMovingSpeed => baseMovingSpeed;
        public int BaseDamage => baseDamage;
    }
}