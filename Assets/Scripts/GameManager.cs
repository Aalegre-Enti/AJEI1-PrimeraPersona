using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int destruibles = 0;
    public int destruiblesTotales = 0;
    float gameOver = 0;

    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if(destruiblesTotales < destruibles)
        {
            destruiblesTotales = destruibles;
        }
        if(destruibles <= 0)
        {
            StartCoroutine(GameOver_Coroutine());
            //gameOver += Time.deltaTime;
            //if(gameOver > 5)
            //{
            //    Exit();
            //}
        }
    }

    IEnumerator GameOver_Coroutine()
    {
        yield return new WaitForSeconds(5);
        Exit();
    }

    void Exit()
    {
        Debug.Log("Juego terminado");
        Application.Quit();
    }
}
