using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClick : MonoBehaviour
{
    [SerializeField] UnityEvent onClick;
    public void OnMouseDown()
    {
        onClick.Invoke();
    }

}
