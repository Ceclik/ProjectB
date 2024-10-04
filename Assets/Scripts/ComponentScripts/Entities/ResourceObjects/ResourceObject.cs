using DataClasses;

namespace ComponentScripts.Entities.ResourceObjects
{
    public class ResourceObject : Entity
    {
        public ItemData[] DroppingItems { get; protected set; }
        
    }
}