using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHand : MonoBehaviour
{
    RectTransform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
    }
    
    void Update()
    {
        transform.anchoredPosition = new Vector3(Mathf.Lerp(-200, 200, Mathf.PingPong(Time.time, 1)), transform.position.y + 116f, transform.position.z);
    }
}
