using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class Character : ActiveEntity
    {
        
        private int _experienceLevel { get; }
        private int _experienceAmount { get; set; }
        [Space(10)][Header("Character's stats")]
        [SerializeField] private int coins;
    }
}