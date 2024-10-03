using BoxObject;
using UnityEngine;

public class BoxContainer : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private BoostersContainer _boosterContainer;
    [SerializeField] private ParticleSystem _particleSystem;

    private Box[] _boxes;

    private void Awake()
    {
        _boosterContainer.Create();
        Fill();
    }

    private void Fill()
    {
        _boxes = new Box[_path.childCount];

        for (int i = 0; i < _boxes.Length; i++)
        {
            if (_path.GetChild(i).TryGetComponent(out Box box))
            {
                FillBoxesType(box, _boxes[i], ObjectsName.Positive);
                FillBoxesType(box, _boxes[i], ObjectsName.Negative);
                FillBoxesType(box, _boxes[i], ObjectsName.Default);
            }
        }
    }

    private void FillBoxesType(Box box, Box currentBox, ObjectsName boxName)
    {

        Booster[] boosters = _boosterContainer.GetBoostersType(box.Name);
        currentBox = box;
        currentBox.Init(GetRandomBooster(boosters), _particleSystem);

    }

    private Booster GetRandomBooster(Booster[] boosters)
    {
        int minLength = 0;
        return boosters[Random.Range(minLength, boosters.Length)];
    }
}