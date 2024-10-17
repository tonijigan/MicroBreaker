using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocationCreateView : MonoBehaviour
{
    private const int CountCreateObjects = 20;

    [SerializeField] private Location[] _locations;
    [SerializeField] private LocationChooseInput _chooseInput;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _spawnCenter;

    private List<GameObject> _gameObjects = new();
    private List<Vector3> _localPositions = new();

    private void Awake()
    {
        Create(CountCreateObjects);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _chooseInput.LocationChoosed += OnChoosed;
    }

    private void OnDisable()
    {
        _chooseInput.LocationChoosed -= OnChoosed;
    }

    private void Create(int countObject)
    {
        for (int i = 0; i < countObject; i++)
        {
            GameObject currentObject = Instantiate(_gameObject, _spawnCenter);
            currentObject.SetActive(false);
            _gameObjects.Add(currentObject);
            _localPositions.Add(Vector3.zero);
        }
    }

    private void OnChoosed(LocationObject locationObject)
    {
        foreach (var currentObject in _gameObjects)
            currentObject.SetActive(false);

        Debug.Log(locationObject.Name);

        var newLocation = _locations.Where(location => location.LocationName == locationObject.Name.ToString()).FirstOrDefault();

        if (newLocation == null)
            return;

        if (newLocation.BoxContainer.transform.childCount > _gameObjects.Count)
            Create(newLocation.BoxContainer.transform.childCount - _gameObjects.Count);

        Debug.Log(_localPositions.Count);

        for (int i = 0; i < newLocation.BoxContainer.transform.childCount; i++)
        {
            _localPositions[i] = newLocation.BoxContainer.transform.GetChild(i).transform.localPosition;
            _gameObjects[i].transform.localPosition = _localPositions[i];
            _gameObjects[i].gameObject.SetActive(true);
        }



        _spawnCenter.DORotate(new Vector3(0f, 360f, 0f), 10, RotateMode.FastBeyond360).SetLoops(-1).SetRelative().SetEase(Ease.Linear);
    }
}