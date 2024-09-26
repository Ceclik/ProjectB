namespace ComponentScripts.Items.Food
{
    public class Meat : Food
    {
        private void Start()
        {
            Name = "Meat";
            MaxAvailableAmount = 6;
        }

        public Meat(Food otherFood) : base(otherFood)
        {
        }
    }
}