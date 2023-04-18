using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonerBicak : MonoBehaviour
{
    public GameObject yoldas; // Elle at�yoruz. Bu yolda��n etraf�nda don�yor.
    Vector3 pos;
    public float minPos = -2.5f;
    public float maxPos = 2.5f;

    private void Start()
    {if
        (yoldas != null)
        {
            pos = yoldas.transform.position;
        }
    }
    void Update()
    {
        if (yoldas != null)
        {
            transform.RotateAround(pos, Vector3.up, 20 * Time.deltaTime); // Yolda��n etraf�nda d�nme.
            transform.Rotate(0, 1, 0, Space.World); // Kendi etraf�nda d�nme.
        }
        else
        {

            transform.Rotate(0, 0, 1, Space.World); // Kendi etraf�nda d�nme.
             
            transform.position = new Vector3(Mathf.Lerp(minPos, maxPos, Mathf.PingPong(Time.time, 1)), transform.position.y, transform.position.z);  // D�z yolda sa�a sola gitme.
        }
    }
}
