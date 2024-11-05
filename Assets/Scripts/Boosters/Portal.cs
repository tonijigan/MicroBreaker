using BallObject;
using FenceObject;
using System.Linq;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Fence[] _fences;

    public void Open(bool isOpen)
    {
        foreach (var fence in _fences)
            fence.ActivePortal(isOpen);
    }

    private void OnEnable()
    {
        foreach (var fence in _fences) fence.PortalMoved += RelocateBall;
    }

    private void OnDisable()
    {
        foreach (var fence in _fences) fence.PortalMoved -= RelocateBall;
    }

    private void RelocateBall(BallMovement ballMovement, Vector3 currentPoint, Vector3 direction, string currentNameFence)
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