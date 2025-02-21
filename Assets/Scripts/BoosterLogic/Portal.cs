using System.Linq;
using BallObject;
using Envierment;
using UnityEngine;

namespace BoosterLogic
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Fence[] _fences;

        private void OnEnable()
        {
            foreach (var fence in _fences) fence.PortalMoved += OnRelocateBall;
        }

        private void OnDisable()
        {
            foreach (var fence in _fences) fence.PortalMoved -= OnRelocateBall;
        }

        public void Open(bool isOpen)
        {
            foreach (var fence in _fences) fence.ActivePortal(isOpen);
        }

        private void OnRelocateBall(BallMovement ballMovement, Vector3 currentPoint, Vector3 direction, string currentNameFence)
        {
            Fence currentFence = GetCurrentFence(currentNameFence);
            Vector3 newPosition;
            Vector3 newDirection;

            if (currentFence.IsHorizontal)
            {
                newPosition = new(currentPoint.x, currentPoint.y, currentFence.PortalPoint.position.z);
                newDirection = new(direction.x, direction.y, -direction.z);
            }
            else
            {
                newPosition = new(currentFence.PortalPoint.position.x, currentPoint.y, currentPoint.z);
                newDirection = new(-direction.x, direction.y, direction.z);
            }

            ballMovement.transform.position = newPosition;
            ballMovement.Move(newDirection);
        }

        private Fence GetCurrentFence(string currentNameFence)
        {
            return _fences.Where(fence => fence.name == currentNameFence).FirstOrDefault().ParallelFence;
        }
    }
}