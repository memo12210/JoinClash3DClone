using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    GameObject friend;

    public float boostTimer;
    public bool Boosting;
    public float movementSpeed;

    private void Awake()
    {
        player = GameObject.Find("Player");
        friend = GameObject.Find("Friend");
        Boosting = player.GetComponent<PlayerMovements>().boosting;
        movementSpeed = 10f;
    }

    void Update()
    {
        if (Boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 2)
            {
                movementSpeed = 10f;
                boostTimer = 0;
                Boosting = false;
            }
        }
    }
}
