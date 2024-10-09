using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] private ScenesName _scenesName;
    [SerializeField] private LocationChooseInput _locationChooseInput;
    [SerializeField] private Save _save;

    private void OnEnable()
    {
        _locationChooseInput.LocationChoosed += OnStart;
    }

    private void OnDisable()
    {
        _locationChooseInput.LocationChoosed += OnStart;
    }

    private void OnStart(LocationObject locationObject)
    {
        _save.SetName(locationObject.Name.ToString());
        SceneManager.LoadScene(_scenesName.ToString());
    }
}