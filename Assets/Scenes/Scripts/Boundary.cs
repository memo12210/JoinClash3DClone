using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    void Update()
    {
        float xPozisyon = Mathf.Clamp(transform.position.x,-4f,4f);
        float zPozisyon = Mathf.Clamp(transform.position.z,0f,250f);
        transform.position = new Vector3(xPozisyon,transform.position.y,zPozisyon);
        
    }
}
