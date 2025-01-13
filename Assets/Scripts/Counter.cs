using System;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _wait;
    [SerializeField] private float _count;
    [SerializeField] private bool _isWorking;

    private Coroutine _counterCoroutine;

    public event Action<float> ChangeCounterView;
    public float Count => _count;

    private void Start()
    {
        _isWorking = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isWorking = !_isWorking;
            HandleWorkCounter(_isWorking);
        }
    }

    private void HandleWorkCounter(bool isWork)
    {
        if (isWork == false && _counterCoroutine != null)
        {
            StopCoroutine(_counterCoroutine);
            return;
        }

        _counterCoroutine = StartCoroutine(Counting());
    }

    private IEnumerator<WaitForSeconds> Counting()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_wait);
        
        while (true)
        {
            yield return waitForSeconds;
            _count += 1;
            ChangeCounterView?.Invoke(_count);
        }
    }
}
