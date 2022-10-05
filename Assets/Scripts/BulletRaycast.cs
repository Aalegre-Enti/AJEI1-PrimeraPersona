using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRaycast : MonoBehaviour
{
    public LineRenderer line;
    public string tag = "Enemy";
    public void Fire()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.collider.tag);
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green, 1);
            if(hit.collider.tag == tag)
            {
                hit.collider.GetComponent<Destruible>().Ejecutar();
            }
            line.SetPosition(1, Vector3.forward * hit.distance);
            StartCoroutine(QuitarLinea());
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1000, Color.red, 1);

            line.SetPosition(1, Vector3.forward * 1000);
            StartCoroutine(QuitarLinea());
        }
    }

    IEnumerator QuitarLinea()
    {
        yield return new WaitForSeconds(0.1f);
        line.SetPosition(1, new Vector3(0,0,0));
    }
}
