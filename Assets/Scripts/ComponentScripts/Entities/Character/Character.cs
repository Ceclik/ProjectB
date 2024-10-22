using ComponentScripts.Entities.Character.InventoryScripts;
using ComponentScripts.Items.Weapons;
using DataClasses;
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

        private Inventory _inventory;

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
            if (_inventory.MainHand is { Name: "Sword" })
            {
                WeaponData swordData = (WeaponData)_inventory.MainHand;
                ActualDamage += swordData.AdditionalDamage;
            }
        }
    }
}