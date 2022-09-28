using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericGun : MonoBehaviour
{
    public int clip_ammo_count;
    public int clip_ammo_max;
    public int inventory_ammo_count;
    public int inventory_ammo_max;
    public float reload_time = 0.5f;
    bool reloading;
    public bool automatic;
    public float firing_speed;
    float lastBullet;
    public UnityEvent onFire;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (automatic)
        {
            if (Input.GetButton("Fire1"))
            {
                FireBullet();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                FireBullet();
            }
        }

        lastBullet += Time.deltaTime;

        if (Input.GetButtonDown("Reload") && !reloading)
        {
            StartCoroutine(Reload_Corutine());
        }
    }

    void FireBullet()
    {
        if (clip_ammo_count > 0 && lastBullet >= firing_speed)
        {
            lastBullet = 0;
            clip_ammo_count--;
            onFire.Invoke();
            Debug.Log("He disparado");
        }
    }
    IEnumerator Reload_Corutine()
    {
        reloading = true;
        Debug.Log("Reloaded");

        yield return new WaitForSeconds(reload_time);

        inventory_ammo_count = inventory_ammo_count + clip_ammo_count;
        clip_ammo_count = Mathf.Clamp(inventory_ammo_count, 0, clip_ammo_max);
        inventory_ammo_count = inventory_ammo_count - clip_ammo_count;
        reloading = false;
    }
}
