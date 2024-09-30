using Interfaces;
using UnityEngine;

namespace FenceObject
{
    public class Fence : MonoBehaviour, ITrigger
    {
        public float GetSpeed()
        {
            float speed = 20;
            return speed;
        }
    }
}