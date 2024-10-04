using UnityEngine;

namespace BallObject
{
    public class BallModification : ObjectModification
    {
        protected override void ChangeScale()
        {
            float scaleValue = 1.2f;
            Vector3 scale = transform.localScale * scaleValue;
            Transform.localScale = scale;
        }

        protected override void ChangeRigidbody()
        {
            Debug.Log("Ball RB");
        }

        protected override void ChangeMesh()
        {
            Debug.Log("Ball Mesh");
        }
    }
}