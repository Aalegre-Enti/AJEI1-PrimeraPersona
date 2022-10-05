using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destruible : MonoBehaviour
{
    public UnityEvent alEjecutar;
    private void Start()
    {
        GameManager.instance.destruibles++;
    }
    public void Ejecutar()
    {
        alEjecutar.Invoke();
        GameManager.instance.destruibles--;
    }
}
