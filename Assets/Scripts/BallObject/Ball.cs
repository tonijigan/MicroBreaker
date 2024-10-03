using UnityEngine;

namespace BallObject
{
    [RequireComponent(typeof(BallMovement))]
    public class Ball : MonoBehaviour, IBallChange
    {
        [SerializeField] private BallTemplate _template;
        [SerializeField] private Transform _templatePoint;

        private Transform _transform;
        private BallMovement _ballMovement;

        private BallTemplate _currentTemplate;

        public bool IsActive { get; private set; } = false;

        private void Awake()
        {
            _transform = transform;
            _currentTemplate = _template;
            _ballMovement = GetComponent<BallMovement>();
        }

        public void DisconnectParentObject()
        {
            if (IsActive)
                return;

            IsActive = true;
            _transform.parent = default;
            _ballMovement.StartMove(Vector3.forward);
        }

        public void Change(BallTemplate ballTemplate)
        {
            ballTemplate.transform.position = _currentTemplate.transform.position;
            ballTemplate.transform.SetParent(_transform);
            ballTemplate.gameObject.SetActive(true);
            _currentTemplate.gameObject.SetActive(false);
            _currentTemplate.transform.parent = null;
            _currentTemplate = ballTemplate;
        }
    }
}