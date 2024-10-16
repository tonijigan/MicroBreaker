using UnityEngine;

public class ContainerLocationObjects : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }
}