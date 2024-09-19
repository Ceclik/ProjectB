using UnityEngine;

namespace ComponentScripts.Items.Food
{
    public abstract class Food : Item
    {
        [SerializeField] private int amountOfRestoringHungerUnits;

        public int AmountOfRestoringHungerUnits => amountOfRestoringHungerUnits;
    }
}