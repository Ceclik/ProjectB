using ComponentScripts.Entities.ResourceObjectScripts;
using NavMeshPlus.Components;
using UnityEngine;

namespace NavMeshComponents
{
    public class NavMeshUpdatorByDestroyedObjects : MonoBehaviour
    {
        private GameObject[] _destroyableGameObjects;
        private NavMeshSurface _surface;
        public ObjectDestroyer[] DestroyableObjects { get; private set; }

        private void Awake()
        {
            _surface = GetComponent<NavMeshSurface>();
            _destroyableGameObjects = GameObject.FindGameObjectsWithTag("DestroyableNavObject");
            DestroyableObjects = new ObjectDestroyer[_destroyableGameObjects.Length];
            for (var i = 0; i < _destroyableGameObjects.Length; i++)
                DestroyableObjects[i] = _destroyableGameObjects[i].GetComponent<ObjectDestroyer>();

            foreach (var destroyableObject in DestroyableObjects)
                destroyableObject.OnObjectDestroyed += UpdateMesh;
        }

        private void Start()
        {
            _surface.BuildNavMeshAsync();
        }

        private void OnDestroy()
        {
            foreach (var destroyableObject in DestroyableObjects)
                destroyableObject.OnObjectDestroyed -= UpdateMesh;
        }

        private void UpdateMesh()
        {
            _surface.UpdateNavMesh(_surface.navMeshData);
        }
    }
}