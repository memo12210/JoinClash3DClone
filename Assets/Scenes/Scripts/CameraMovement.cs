using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject playerObj;
    Vector3 cameraOffSet;
    void Start()
    {
        playerObj = GameObject.Find("Player");
        // cameraOffSet = new Vector3(0, 5, -14);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerObj != null)
        {
            transform.position = new Vector3(0, 17, playerObj.transform.position.z - 12);
        }
    }
}
