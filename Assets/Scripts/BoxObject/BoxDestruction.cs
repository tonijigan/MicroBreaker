using UnityEngine;

namespace BoxObject
{
    [RequireComponent(typeof(Box))]
    public class BoxDestruction : MonoBehaviour
    {
        [SerializeField] private Transform _boxTemplate;
        [SerializeField] private Transform _boxDestructionTemplate;

        private Box _box;

        private void Awake()
        {
            _box = GetComponent<Box>();
        }

        private void OnEnable()
        {
            _box.Died += OnDied;
        }

        private void OnDisable()
        {
            _box.Died -= OnDied;
        }

        private void OnDied()
        {
            _boxTemplate.gameObject.SetActive(false);
            _boxDestructionTemplate.gameObject.SetActive(true);
        }
    }
}