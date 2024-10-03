using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private BoxName _name;

    public BoxName Name => _name;

    private void Update()
    {
        transform.Translate(new(0, 0, -1 * _speed * Time.deltaTime));
    }
}