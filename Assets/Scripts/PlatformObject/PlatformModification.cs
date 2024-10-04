using UnityEngine;

namespace PlatformObject
{
    public class PlatformModification : ObjectModification
    {
        protected override void ChangeMesh()
        {
            Debug.Log("PlatformMesh");
        }

        protected override void ChangeRigidbody()
        {
            Debug.Log("PlatformRB");
        }

        protected override void ChangeScale()
        {
            Debug.Log("PlatformScale");
        }
    }
}