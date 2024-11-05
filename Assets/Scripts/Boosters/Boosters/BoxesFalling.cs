using Boosters;
using BoxObject;
using UnityEngine;

public class BoxesFalling : AbstractBooster
{
    [SerializeField] private Transform _pathBoxesContainer;
    [SerializeField] private ParticleSystem _particleSystem;

    public Box[] Boxes { get; private set; }

    public bool IsActive { get; private set; } = false;

    private void Start() => Fill();

    private void Fill()
    {
        Boxes = new Box[_pathBoxesContainer.childCount];

        for (int i = 0; i < Boxes.Length; i++)
        {
            _pathBoxesContainer.GetChild(i).TryGetComponent(out Box box);
            Boxes[i] = box;
            Boxes[i].Init(_particleSystem);
        }
    }

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        IsActive = true;
        _pathBoxesContainer.gameObject.SetActive(true);
        boosterEffect.SetActionActive();
    }

    public override void StopAction(BoosterEffect boosterEffect)
    {
        IsActive = false;
        Debug.Log("Кубы наверное будут уничтожены");
        boosterEffect.SetActionActive();
    }
}