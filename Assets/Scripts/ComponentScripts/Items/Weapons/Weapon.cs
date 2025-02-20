using ComponentScripts.Items.Tools;
using UnityEngine;

namespace ComponentScripts.Items.Weapons
{
    public class Weapon : Tool
    {
        [SerializeField] private int additionalDamage;

        public int AdditionalDamage => additionalDamage;
    }
}