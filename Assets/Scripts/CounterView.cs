using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ChangeCounterView += ChangeTextCounter;
    }

    private void OnDisable()
    {
        _counter.ChangeCounterView -= ChangeTextCounter;
    }

    private void ChangeTextCounter(float newCount)
    {
        _text.text = newCount.ToString();
    }
}
