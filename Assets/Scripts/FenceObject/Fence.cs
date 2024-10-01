using Interfaces;

namespace FenceObject
{
    public class Fence : AbstractEffect, ITrigger
    {
        public float GetSpeed()
        {
            float speed = 20;
            return speed;
        }
    }
}