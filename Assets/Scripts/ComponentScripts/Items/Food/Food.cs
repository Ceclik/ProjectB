using UnityEngine;

namespace ComponentScripts.Items.Food
{
    public class Food : Item
    {
        [SerializeField] private int amountOfRestoringHungerUnits;

        public int AmountOfRestoringHungerUnits => amountOfRestoringHungerUnits;

        public Food(Food otherFood) : base(otherFood)
        {
            amountOfRestoringHungerUnits = otherFood.amountOfRestoringHungerUnits;
        }
    }
}