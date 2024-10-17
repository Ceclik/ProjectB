using UnityEditor;
using UnityEngine;

namespace ComponentScripts.Items.Tools
{
    public class Shield : Tool
    {
        [SerializeField] [Range(0,100)] private float percentOfBlockingDamage;

        public float PercentOfBlockingDamage => percentOfBlockingDamage;
    }
}