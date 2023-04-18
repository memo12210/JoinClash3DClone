using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompanionCollider : MonoBehaviour
{
    public GameObject Player;
    public GameObject Companion;


        void OnCollisionEnter(Collision collisionInfo)
        {

        
    

        if (collisionInfo.collider.tag == "Player")
        {
            Companion.transform.parent = Player.transform;

        }
        
        if (collisionInfo.collider.tag == "Obstacles")
        {
            Destroy(Companion);
        }

        
        }
}


