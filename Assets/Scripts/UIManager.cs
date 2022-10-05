using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI enemigos;
    public TextMeshProUGUI balas;
    public TextMeshProUGUI youwon;
    public GenericGun currentGun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemigos.text = GameManager.instance.destruibles + " / " + GameManager.instance.destruiblesTotales;
        tiempo.text = Time.time.ToString("00.00");
        balas.text = currentGun.clip_ammo_count + "/" + currentGun.inventory_ammo_count;

        if(GameManager.instance.destruibles <= 0)
        {
            youwon.gameObject.SetActive(true);
        }
    }
}
