using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    private const string SceneGame = "Game1";

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
        SceneManager.LoadScene(SceneGame);
    }
}