using ComponentScripts.Items.Food;

namespace DataClasses
{
    public class FoodData : ItemData
    {
        public FoodData(Food otherFood) : base(otherFood)
        {
            AmountOfRestoringHungerUnits = otherFood.AmountOfRestoringHungerUnits;
        }

        public int AmountOfRestoringHungerUnits { get; private set; }
    }
}