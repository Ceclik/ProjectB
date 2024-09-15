using Services.BaseEntityServices;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Entities
{
    public class EntityHealthHandler : MonoBehaviour
    {
        private IEntityDamageReceiver _entityDamageReceiver;
        [SerializeField] private Image healthBar;

        public void Inject(IEntityDamageReceiver entityDamageReceiver)
        {
            _entityDamageReceiver = entityDamageReceiver;
        }

        public void ReceiveCharacterAttack(Character.Character character)
        {
            _entityDamageReceiver.ReceiveDamage(character, GetComponent<Entity>());
            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            healthBar.fillAmount =
                (float)GetComponent<Entity>().ActualHealth * 100 / GetComponent<Entity>().BaseHealth / 100;
        }
    }
}