using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosivo : MonoBehaviour
{
    public float time = 3;
    float currentTime;
    public float radius = 2;
    public string tag = "Enemigo";
    void Start()
    {
        currentTime = time;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            Explosion();
        }
    }

    public void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == tag)
            {
                colliders[i].GetComponent<Destruible>().Ejecutar();
            }
        }
        Destroy(gameObject);
    }
}
