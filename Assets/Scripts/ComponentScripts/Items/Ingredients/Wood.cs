using System;

namespace ComponentScripts.Items.Ingredients
{
    public class Wood : Ingredient
    {
        private void Start()
        {
            Name = "Wood";
            MaxAvailableAmount = 20;
        }
    }
}