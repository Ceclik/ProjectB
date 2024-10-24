using UnityEngine;

namespace ComponentScripts.Items.Tools
{
    public class Shield : Tool
    {
        [SerializeField] [Range(0, 100)] private float percentOfBlockingDamage;
        [SerializeField] [Range(0, 100)] private float percentOfSlowingCharacter;

        public float PercentOfBlockingDamage => percentOfBlockingDamage;
        public float PercentOfSlowingCharacter => percentOfSlowingCharacter;
    }
}