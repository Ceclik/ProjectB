using Services.BaseEntityServices;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Entities.Enemies
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyHealthHandler : MonoBehaviour
    {
        private IEnemyDamageReceiver _enemyDamageReceiver;
        [SerializeField] private Image healthBar;

        public void Inject(IEnemyDamageReceiver enemyDamageReceiver)
        {
            _enemyDamageReceiver = enemyDamageReceiver;
        }

        public void ReceiveCharacterAttack(Character.Character character)
        {
            _enemyDamageReceiver.ReceiveDamage(character, GetComponent<Enemy>());
            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            healthBar.fillAmount =
                (float)GetComponent<Enemy>().ActualHealth * 100 / GetComponent<Enemy>().BaseHealth / 100;
        }
    }
}