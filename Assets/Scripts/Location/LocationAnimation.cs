using BoxObject;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationAnimation : MonoBehaviour
{
    private const int HightPosition = 20;
    private const int MinValue = 0;
    private const float FirstDuration = 0.5f;
    private const float SecondDuration = 0.03f;
    private const float FirstAngle = 360f;
    private const float SecondAngle = 180f;

    private Box[] _boxesTransform;
    private Transform _transform;
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds = new(1);

    private void Start()
    {
        _transform = transform;
        _boxesTransform = new Box[_transform.childCount];

        for (int i = 0; i < _boxesTransform.Length; i++)
        {
            _transform.GetChild(i).TryGetComponent(out Box box);
            _boxesTransform[i] = box;
            _boxesTransform[i].SetKinematic(true);
        }

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        List<Vector3> positions = new();

        for (int i = 0; i < _boxesTransform.Length; i++)
        {
            positions.Add(_boxesTransform[i].transform.position);
            _boxesTransform[i].transform.DOMove(_transform.position + (Vector3.up + Vector3.forward) * HightPosition, MinValue);
        }

        yield return _waitForSeconds;

        for (int i = 0; i < _boxesTransform.Length; i++)
        {
            MoveWithRotate(positions[i], i, FirstDuration, FirstAngle);
            yield return _waitForSeconds = new(SecondDuration);
        }

        yield return _waitForSeconds = new(FirstDuration);

        for (int i = 0; i < _boxesTransform.Length; i++)
        {
            MoveWithRotate(positions[i] + Vector3.up, i, FirstDuration, SecondAngle);
            yield return _waitForSeconds = new(SecondDuration);
        }

        for (int i = 0; i < _boxesTransform.Length; i++)
        {
            MoveWithRotate(positions[i], i, FirstDuration, SecondAngle);
            _boxesTransform[i].SetKinematic(false);
            yield return _waitForSeconds = new(SecondDuration);
        }

        StopCoroutine(_coroutine);
    }

    private void MoveWithRotate(Vector3 position, int index, float duration, float angleY)
    {
        _boxesTransform[index].transform.DOMove(position, duration);
        _boxesTransform[index].transform.DORotate(new Vector3(MinValue, angleY, MinValue), duration, RotateMode.FastBeyond360);
    }
}