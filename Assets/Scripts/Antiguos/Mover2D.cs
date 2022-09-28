using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2D : MonoBehaviour
{
    public float velocidad = 0.1f;
    void Start()
    {

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3 (horizontal, vertical);
        transform.position = transform.position + movimiento * velocidad * Time.deltaTime;
        Debug.Log(movimiento);
    }
}
