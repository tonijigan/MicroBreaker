using Boosters;
using BoxObject;
using UnityEngine;

public class BoxesFalling : AbstractBooster
{
    [SerializeField] private Transform _pathBoxesContainer;
    [SerializeField] private ParticleSystem _particleSystem;

    private Box[] _boxes;

    private void Start() => Fill();

    private void Fill()
    {
        _boxes = new Box[_pathBoxesContainer.childCount];

        for (int i = 0; i < _boxes.Length; i++)
        {
            _pathBoxesContainer.GetChild(i).TryGetComponent(out Box box);
            _boxes[i] = box;
            _boxes[i].Init(_particleSystem);
        }
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        _pathBoxesContainer.gameObject.SetActive(true);
        boosterEffect.SetActionActive();
    }
    public override void StopAction(BoosterEffect boosterEffect)
    {
        Debug.Log("Кубы наверное будут унечтожены");
        boosterEffect.SetActionActive();
    }
}