using DataClasses;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts.Entities.Character.InventoryScripts
{
    public class StatusHandPanelsHandler : MonoBehaviour
    {
        [SerializeField] Image mainHandImage;
        [SerializeField] Image secondHandImage;

        private Inventory _inventory;

        private void Start()
        {
            _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            _inventory.OnMainHandUpdate += UpdateMainHand;
            _inventory.OnSecondHandUpdate += UpdateSecondHand;
        }

        private void UpdateMainHand(ItemData item)
        {
            mainHandImage.sprite = item?.ItemIcon;
        }

        private void UpdateSecondHand(ItemData item)
        {
            secondHandImage.sprite = item?.ItemIcon;
        }

        private void OnDestroy()
        {
            _inventory.OnMainHandUpdate -= UpdateMainHand;
            _inventory.OnSecondHandUpdate -= UpdateSecondHand;
        }
    }
}