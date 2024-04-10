using System.Collections;
using TMPro;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private TextMeshProUGUI _textNumber;

    private Coroutine _coroutine;

    private int _number;

    private bool _isClicked;

    private void Start()
    {
        DislpayCountDown(_number, _textNumber);
        Restart();
    }

    private void Update()
    {
        bool isMouseClicked = Input.GetKeyDown(KeyCode.Mouse0);

        if (isMouseClicked && _isClicked == false)
        {
            _number++;
            _isClicked = true;
        }
        else if (isMouseClicked && _coroutine == null && _isClicked)
        {
            Restart();
            _isClicked = false;
        }
        else if (isMouseClicked && _isClicked)
        {
            Stop();
        }
    }

    private void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void Restart()
    {
        _coroutine = StartCoroutine(RunCountDown(_delay));
    }

    private IEnumerator RunCountDown(float delay)
    {
        var wait = new WaitForSecondsRealtime(delay);

        while (true)
        {
            _number++;
            DislpayCountDown(_number, _textNumber);
            yield return wait;
        }
    }

    private void DislpayCountDown(float number, TextMeshProUGUI text)
    {
        text.text = number.ToString();
    }
}
