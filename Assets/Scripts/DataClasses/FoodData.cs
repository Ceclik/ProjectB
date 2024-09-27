using ComponentScripts.Items.Food;

namespace DataClasses
{
    public class FoodData : ItemData
    {
        public int AmountOfRestoringHungerUnits { get; private set; }
        
        public FoodData(Food otherFood) : base(otherFood)
        {
            AmountOfRestoringHungerUnits = otherFood.AmountOfRestoringHungerUnits;
        }
    }
}