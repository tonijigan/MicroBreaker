using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Booster booster))
        {
            booster.gameObject.SetActive(false);
            Debug.Log("Бостер доставлен");
        }
    }
}