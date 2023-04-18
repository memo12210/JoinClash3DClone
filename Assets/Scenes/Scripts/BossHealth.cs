using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;

    GameObject progressBar = default;

    void Start()
    {
        progressBar = GameObject.Find("Canvas (1)");
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();

        if(health<maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if(health>maxHealth)
        {
            health = maxHealth;
        }
        if(health<= 0)
        {
            GetComponent<Animator>().SetBool("isPlayerReached",false);
            GetComponent<Animator>().SetBool("isDead", true);
            Invoke("Die", 1.33f);
            progressBar.SetActive(false);
        }
    }

    void Die() { 
        gameObject.SetActive(false); 
    }
    
    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
