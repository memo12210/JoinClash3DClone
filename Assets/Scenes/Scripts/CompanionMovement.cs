using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour
{

    public GameObject player;
    bool isCollidePlayer;
    public float forwardSpeed = 5f;
    public float sideSpeed = 3f;
    
    void OnCollisionEnter(Collision collisionInfo)
        {

        
    

        if (collisionInfo.collider.tag == "Player")
        {
            isCollidePlayer = true;
        }
        
        if (collisionInfo.collider.tag == "Obstacles")
        {
            Destroy(gameObject);
        }

        
        }
    void Update()
    {
        
        float xPozisyon = Mathf.Clamp(transform.position.x,-3.6f,3.6f);
        float zPozisyon = Mathf.Clamp(transform.position.z,0f,72f);
        transform.position = new Vector3(xPozisyon,transform.position.y,zPozisyon);

    }
}
