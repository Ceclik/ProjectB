using ComponentScripts.Entities.Character.InventoryScripts;
using DataClasses;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class Character : ActiveEntity
    {
        [Space(10)] [Header("Character's stats")] [SerializeField]
        private int coins;

        private Inventory _inventory;

        private int _experienceLevel { get; }
        private int _experienceAmount { get; set; }
        public int ActualMaxHealth { get; private set; }
        public int ActualDamage { get; private set; }

        private void Start()
        {
            _inventory = GetComponent<Inventory>();

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
            if (_inventory.MainHand.Value is { Name: "Sword" })
            {
                var swordData = (WeaponData)_inventory.MainHand.Value;
                ActualDamage += swordData.AdditionalDamage;
            }
        }
    }
}