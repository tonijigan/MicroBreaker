using UnityEngine;

public class Save : MonoBehaviour
{
    private const string CurrentName = "CurrentLocation";

    private void Awake()
    {
        Debug.Log(GetName());
    }

    public string GetName()
    {
        return PlayerPrefs.GetString(CurrentName);
    }

    public void SetName(string locationName)
    {
        PlayerPrefs.SetString(CurrentName, locationName);
    }
}
