using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _wait;
    [SerializeField] private float _count;
    [SerializeField] private CounterController _counterController;

    private Coroutine _counterCoroutine;

    public float Count => _count;

    private void OnWorkCounter(bool isWork)
    {
        if (isWork == false && _counterCoroutine != null)
        {
            Debug.Log("Stop");
            StopCoroutine(_counterCoroutine);
            return;
        }

        Debug.Log("Start");
        _counterCoroutine = StartCoroutine(CounterWait());
    }

    private void OnEnable()
    {
        _counterController.WorkCounter += OnWorkCounter;
    }

    private void OnDisable()
    {
        _counterController.WorkCounter -= OnWorkCounter;
    }

    private IEnumerator<WaitForSeconds> CounterWait()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_wait);
        
        while (true)
        {
            yield return waitForSeconds;
            _count += 1;
        }
    }
}
