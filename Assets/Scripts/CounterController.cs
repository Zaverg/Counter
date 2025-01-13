using System;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    public event Action<bool> WorkCounter;

    [SerializeField] private bool _isWorking;

    private void Start()
    {
        _isWorking = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isWorking = !_isWorking;
            WorkCounter?.Invoke(_isWorking);
        } 
    }
}
