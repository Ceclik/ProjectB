using UnityEngine;

namespace ComponentScripts.Items.Weapons
{
    public class Weapon : Item
    {
        [SerializeField] private int additionalDamage;

        public int AdditionalDamage => additionalDamage;
    }
}