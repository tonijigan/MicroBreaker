using UnityEngine;
using Enums;
using DG.Tweening;

public class LocationObject : MonoBehaviour
{
    private const int MinValue = 0;
    private const int LoopValue = 1;
    private const float HightValue = 0.2f;
    private const float DurationMove = 0.5f;
    private const float DurationRotate = 10;
    private const float Angle = 360;

    [SerializeField] private LocationName _name;
    [SerializeField] private bool _isActive;
    [SerializeField] private Transform _boxTransform;
    [SerializeField] private Color _colorPassed;
    [SerializeField] private Color _colorStart;
    [SerializeField] private Color _colorAccess;
    private Material _material;

    public bool IsPassed { get; private set; } = false;

    public LocationName Name => _name;

    public bool IsActive => _isActive;

    private void Start()
    {
        SetAccess();
        _boxTransform.DOLocalMove(Vector3.up * HightValue, DurationMove).SetEase(Ease.InOutSine).SetLoops(-LoopValue, LoopType.Yoyo);
        _boxTransform.DOLocalRotate(new Vector3(MinValue, Angle, MinValue), DurationRotate, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-LoopValue, LoopType.Incremental);
    }

    public void SetActive()
    {
        _isActive = true;
        SetAccess();
    }

    public void SetPassed(bool isPassed)
    {
        IsPassed = isPassed;
        SetAccess();
    }

    private void SetAccess()
    {
        _boxTransform.GetComponent<MeshRenderer>().material.color = _colorAccess;

        if (_isActive == true)
            _boxTransform.GetComponent<MeshRenderer>().material.color = _colorStart;

        if (IsPassed == true)
            _boxTransform.GetComponent<MeshRenderer>().material.color = _colorPassed;
    }
}