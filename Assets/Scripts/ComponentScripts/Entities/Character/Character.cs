using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class Character : ActiveEntity
    {
        
        private int _experienceLevel { get; }
        private int _experienceAmount { get; set; }
        [Space(10)][Header("Character's stats")]
        [SerializeField] private int coins;
        public int ActualMaxHealth { get; private set; }
        public int BaseHealth => baseHealthPoints;
        public int ActualHealth { get; set; }

        private void Start()
        {
            CountActualMaxHealth();
            ActualHealth = ActualMaxHealth;
        }

        private void CountActualMaxHealth()
        {
            ActualMaxHealth = BaseHealth; //TODO count depending on level
        }
    }
}