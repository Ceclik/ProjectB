using ComponentScripts.Items.Weapons;

namespace DataClasses
{
    public class WeaponData : ToolData
    {
        public WeaponData(Weapon otherWeapon) : base(otherWeapon)
        {
            AdditionalDamage = otherWeapon.AdditionalDamage;
        }

        public int AdditionalDamage { get; private set; }
    }
}