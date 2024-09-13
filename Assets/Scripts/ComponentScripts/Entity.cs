using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace ComponentScripts
{
    public abstract class  Entity : MonoBehaviour
    {
        [FormerlySerializedAs("_healthPoints")] [SerializeField] protected int baseHealthPoints;
        protected IDamageReceiver _damageReceiver;
        protected IDespawner _despawner;
        
    }
}
