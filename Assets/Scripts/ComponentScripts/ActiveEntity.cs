using Interfaces.CharacterInterfaces.CharacterAttackInterfaces;
using Services.CharacterServices.CharacterAttackScripts;
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