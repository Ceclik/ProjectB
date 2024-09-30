using System;

namespace ComponentScripts.Items.Weapons
{
    public class Sword : Weapon
    {
        private void Start()
        {
            Name = "Sword";
            MaxAvailableAmount = 1;
        }
    }
}