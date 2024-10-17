using UnityEngine;
using Enums;
using DG.Tweening;

public class LocationObject : MonoBehaviour
{
    [SerializeField] private LocationName _name;
    [SerializeField] private bool _isActive;
    [SerializeField] private Transform _boxTransform;
    public bool IsPassed { get; private set; } = false;

    public LocationName Name => _name;

    public bool IsActive => _isActive;

    private void Start()
    {
        _boxTransform.DOLocalMove(Vector3.up * 0.2f, 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        _boxTransform.DOLocalRotate(new Vector3(0, 360, 0), 10, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }

    public void SetPassed(bool isPassed)
    {
        IsPassed = isPassed;
        _boxTransform.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}