using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] lista;
    public bool randomRotation;
    public bool randomScale;
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, lista.Length);
        float rotation = Random.Range(0, 4) * 90.0f;
        GameObject temporal = Instantiate(lista[index], transform.position, transform.rotation);
        temporal.transform.eulerAngles = new Vector3(0, rotation, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
