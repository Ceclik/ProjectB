using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class Character : ActiveEntity
    {
        [SerializeField] private int coins;
        private int _experienceLevel { get; }
        private int _experienceAmount { get; set; }
        
    }
}