using UnityEngine;

namespace Services.BaseEntityServices
{
    public interface IDespawner
    {
        public void Despawn(GameObject entity);
    }
}