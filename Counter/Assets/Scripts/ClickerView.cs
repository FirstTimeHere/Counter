using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float _smoothDecreaseDuration = 0.5f;
    [SerializeField] private Clicker _clicker;
    [SerializeField] private TextMeshProUGUI _textNumber;

    private void Start()
    {
        _textNumber.text = _clicker.Number.ToString();
    }

    private void OnEnable()
    {
        _clicker.ClickedMouse += ClickMouseButton;
    }

    private void OnDisable()
    {
        _clicker.ClickedMouse -= ClickMouseButton;
    }

    private void ClickMouseButton(int currentNumber)
    {
        StartCoroutine(SumNumberSmoothly(currentNumber));
    }

    private IEnumerator SumNumberSmoothly(float delay)
    {
        float elapsedTime = 0f;

        var wait = new WaitForSeconds(delay);

        while (true)
        {
            DislpayCountDown(elapsedTime);
            elapsedTime++;
            yield return wait;
        }
    }

    private void DislpayCountDown(float elapsedTime)
    {
        _textNumber.text = elapsedTime.ToString("");
    }
}
