using Interfaces;
using Services.BaseEntityServices;
using UnityEngine;

namespace ComponentScripts
{
    public abstract class ActiveEntity : Entity
    {
        [SerializeField] protected float baseMovingSpeed;
        [SerializeField] protected int baseDamage;

        private ICharacterAttackHandler _characterAttackHandler;

        public float BaseMovingSpeed => baseMovingSpeed;
        public int BaseDamage => baseDamage;
    }
}