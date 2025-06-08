using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _delay;
    private Coroutine _coroutine;
    private float _counter = 0f;

    public event Action<float> ValueChanged;
    
    private void Update()
    {
        CounterWork();
    }

    private void CounterWork()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            else
            {
                _coroutine = StartCoroutine(Countdown(_delay));
            }
        }
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);
        bool isWork = true;

        while (isWork)
        {
            yield return wait;

            ValueChanged?.Invoke(_counter);
            _counter++;
        }
    }
}
