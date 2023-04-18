using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonerBicak : MonoBehaviour
{
    public GameObject yoldas; // Elle atýyoruz. Bu yoldaþýn etrafýnda donüyor.
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
            transform.RotateAround(pos, Vector3.up, 20 * Time.deltaTime); // Yoldaþýn etrafýnda dönme.
            transform.Rotate(0, 1, 0, Space.World); // Kendi etrafýnda dönme.
        }
        else
        {

            transform.Rotate(0, 0, 1, Space.World); // Kendi etrafýnda dönme.
             
            transform.position = new Vector3(Mathf.Lerp(minPos, maxPos, Mathf.PingPong(Time.time, 1)), transform.position.y, transform.position.z);  // Düz yolda saða sola gitme.
        }
    }
}
