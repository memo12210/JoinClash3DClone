using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheer : MonoBehaviour
{    void Update()
    {
       if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
       {
           GetComponent<Animator>().SetBool("Attack", false);
           GetComponent<Animator>().SetBool("Cheer", true);
       }
    }
}
