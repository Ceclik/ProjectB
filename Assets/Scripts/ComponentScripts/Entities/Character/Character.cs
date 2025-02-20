using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class Character : ActiveEntity
    {
        [Space(10)] [Header("Character's stats")] [SerializeField]
        private int coins;

        public Inventory Inventory { get; private set; }

        private int _experienceLevel { get; }
        private int _experienceAmount { get; set; }
        public int ActualMaxHealth { get; private set; }
        public int ActualDamage { get; private set; }

        private void Start()
        {
            Inventory = GetComponent<Inventory>();

            CountActualMaxHealth();
            CountActualDamage();
            ActualHealth = ActualMaxHealth;
        }

        private void CountActualMaxHealth()
        {
            ActualMaxHealth = BaseHealth; //TODO count depending on level
        }

        public void CountActualDamage()
        {
            ActualDamage = BaseDamage;
            if (Inventory.MainHand.Value is { Name: "Sword" })
            {
                var swordData = (WeaponData)Inventory.MainHand.Value;
                ActualDamage += swordData.AdditionalDamage;
            }
        }
    }
}