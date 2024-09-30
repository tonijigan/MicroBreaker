using UnityEngine;

public class Fence : MonoBehaviour, ITrigger
{
    public float GetSpeed()
    {
        float speed = 20;
        return speed;
    }
}