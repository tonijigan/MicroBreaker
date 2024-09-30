using UnityEngine;

[RequireComponent(typeof(BallMovement))]
public class Ball : MonoBehaviour
{
    private Transform _transform;
    private BallMovement _ballMovement;

    public bool IsActive { get; private set; } = false;

    private void Awake()
    {
        _transform = transform;
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
}