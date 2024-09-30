using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class Character : ActiveEntity
    {
        [Space(10)] [Header("Character's stats")] [SerializeField]
        private int coins;

        private int _experienceLevel { get; }
        private int _experienceAmount { get; set; }
        public int ActualMaxHealth { get; private set; }
        public int ActualDamage { get; private set; }

        private void Start()
        {
            CountActualMaxHealth();
            CountActualDamage();
            ActualHealth = ActualMaxHealth;
        }

        public void CountActualMaxHealth()
        {
            ActualMaxHealth = BaseHealth; //TODO count depending on level
        }

        public void CountActualDamage()
        {
            ActualDamage = BaseDamage; //TODO count depending on weapon
        }
    }
}