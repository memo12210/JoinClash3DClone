using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDetectPlayer : MonoBehaviour
{
    private GameObject boss;
    private GameObject Player;
    public GameObject canvas;
    private Transform background;
    private Transform backgroundLevelComplete;
    private Transform buttonLevelComplete;
    private Transform button;
    private Transform button2;
    public float health;

    void Awake()
    {
        boss = GameObject.Find("Boss");
        Player = GameObject.Find("Player");
        background = canvas.transform.GetChild(1);
        backgroundLevelComplete = canvas.transform.GetChild(0);
        buttonLevelComplete = backgroundLevelComplete.transform.GetChild(1);
        button = background.transform.GetChild(1);
        button2 = background.transform.GetChild(2);

        health = 1000;
    }


    void Start()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }


    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Obstacles")
        {
            health = 0;
        }
    }

    void Update()
    {
        if(health <= 0)
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
            canvas.SetActive(true);
            canvas.transform.GetChild(0).transform.gameObject.SetActive(false);
            canvas.transform.GetChild(1).transform.gameObject.SetActive(true);
        }

        if(boss.activeSelf == false)
        {
            canvas.SetActive(true);
            canvas.transform.GetChild(0).transform.gameObject.SetActive(true);
            canvas.transform.GetChild(1).transform.gameObject.SetActive(false);

        }

    }
}
