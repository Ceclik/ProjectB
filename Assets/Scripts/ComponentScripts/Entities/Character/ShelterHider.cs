using System.Collections;
using ComponentScripts.CameraScripts;
using ComponentScripts.Entities.Character.InventoryScripts;
using UnityEngine;

namespace ComponentScripts.Entities.Character
{
    public class ShelterHider : MonoBehaviour
    {
        [SerializeField] private float nextHidingDelayTime;
        private ActionTextHandler _actionTextHandler;
        private Collider2D _collider;

        private Shelter _enteredShelter;
        private float _nextHidingTimer;
        private SpriteRenderer _spriteRenderer;
        private Vector3 _farHidedPosition;
        private CameraCharacterFollower _mainCamera;
        public bool IsInShelter { get; private set; }

        private void Start()
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraCharacterFollower>();
            _actionTextHandler = GetComponent<ActionTextHandler>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
            _nextHidingTimer = nextHidingDelayTime + 1;
            _farHidedPosition = new Vector3(30000.0f, 0.0f, 0.0f);
        }

        private void Update()
        {
            if (_nextHidingTimer < nextHidingDelayTime + 1 && !IsInShelter)
                _nextHidingTimer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.F) && _enteredShelter != null) EnterShelter();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_nextHidingTimer > nextHidingDelayTime && other.TryGetComponent(out Shelter shelter))
            {
                _actionTextHandler.ActionText.ShowActionText("Націсніце 'f' каб увайсці ў сховішча",
                    _actionTextHandler.ActionTextElement);
                _enteredShelter = shelter;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _enteredShelter = null;
            _actionTextHandler.ActionText.HideActionText(_actionTextHandler.ActionTextElement);
        }

        private void EnterShelter()
        {
            Vector3 currentPosition = transform.position;
            _mainCamera.enabled = false;
            transform.position = _farHidedPosition;
            StartCoroutine(DisableHidedState(_enteredShelter.HidingTime, currentPosition));
            IsInShelter = true;
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
        }

        private IEnumerator DisableHidedState(float delay, Vector3 characterPosition)
        {
            yield return new WaitForSeconds(delay);
            _mainCamera.enabled = true;
            transform.position = characterPosition;
            _spriteRenderer.enabled = true;
            _collider.enabled = true;
            IsInShelter = false;
            _nextHidingTimer = 0;
        }
    }
}