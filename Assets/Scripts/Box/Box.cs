using UnityEngine;

public class Box : MonoBehaviour, ITrigger
{
    [SerializeField] private float _speedRepulsion;

    public float GetSpeed()
    {
        return _speedRepulsion;
    }
}
