using Services.BaseEntityServices;
using UnityEngine;

namespace ComponentScripts.Entities
{
    public class EntityHealthHandler : MonoBehaviour
    {
        private IEntityDamageReceiver _entityDamageReceiver;

        private EntityHealthBarHandler _healthBarHandler;
        private Entity _selfEntity;

        public void Inject(IEntityDamageReceiver entityDamageReceiver)
        {
            _entityDamageReceiver = entityDamageReceiver;
        }

        private void Start()
        {
            _healthBarHandler = GetComponent<EntityHealthBarHandler>();
            _selfEntity = GetComponent<Entity>();
        }

        public void ReceiveCharacterAttack(Character.Character character)
        {
            _entityDamageReceiver.ReceiveDamage(character, _selfEntity);
            _healthBarHandler.UpdateHealthBar(_selfEntity);
        }
    }
}