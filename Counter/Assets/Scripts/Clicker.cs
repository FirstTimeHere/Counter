using System.Collections;
using TMPro;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private TextMeshProUGUI _textNumber;

    private Coroutine _coroutine;

    private int _number;

    private bool _isUserWantChangedNumber = true;

    private void Start()
    {
        DislpayCountDown(_number, _textNumber);
        Restart();
    }

    private void Update()
    {
        bool _isMouseClicked = Input.GetKeyDown(KeyCode.Mouse0);

        if (_isMouseClicked && _isUserWantChangedNumber)
        {
            _number++;
            _isUserWantChangedNumber = false;
        }
        else if (_isMouseClicked && _coroutine == null && _isUserWantChangedNumber == false)
        {
            Restart();
            _isUserWantChangedNumber = true;
        }
        else if (_isMouseClicked && _isUserWantChangedNumber == false)
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
