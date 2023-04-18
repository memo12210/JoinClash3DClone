using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupCompController : MonoBehaviour
{
    public bool triggered;

    public GameObject[] groupCompanion;
    
    void Start()
    {
    }

    private void Update()
    {
        if (triggered)
        {

            Debug.Log("Triggered");
            for (int i = 0; i < groupCompanion.Length; i++)
            {
                groupCompanion[i].GetComponent<DetectPlayer>().isCollidePlayer = true;
                groupCompanion[i].tag = "CollidedCompanion";
                groupCompanion[i].transform.GetChild(1).GetComponent<Renderer>().material.color = new Color(0, 0.32f, 255);
            }
            triggered = false;
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
      
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("CollidedCompanion"))
            {
                Debug.Log("Nice");
                triggered = true;
            }
        
    }
}
