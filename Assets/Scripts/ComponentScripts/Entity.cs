using Interfaces;
using UnityEngine;

namespace DataClasses
{
    public abstract class  Entity : MonoBehaviour
    {
        [SerializeField] protected int _healthPoints;
        protected IDamageReceiver _damageReceiver;
        protected IDespawner _despawner;
        
    }
}
