using System;
using UnityEngine;
using UnityEngine.Animations;

public class Clicker : MonoBehaviour
{
    private int _number = 0;
    public int Number => _number;
    public event Action<int> ClickedMouse;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _number++;
            Debug.Log("done");
            ClickedMouse?.Invoke(_number);
        }
    }

    //public void MouseDown(int number)
    //{
    //    _number += number;
    //}
}
