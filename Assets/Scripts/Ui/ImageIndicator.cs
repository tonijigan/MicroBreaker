using UnityEngine;
using UnityEngine.UI;

public class ImageIndicator : MonoBehaviour
{
    [SerializeField] private Image _imageCurrentObject;

    public void SetAction(bool action)
    {
        _imageCurrentObject.gameObject.SetActive(action);
    }
}