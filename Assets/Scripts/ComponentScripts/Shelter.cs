using UnityEngine;

namespace ComponentScripts
{
    public class Shelter : MonoBehaviour
    {
        [SerializeField] private float hidingTime;
        
        public float HidingTime => hidingTime;
    }
}