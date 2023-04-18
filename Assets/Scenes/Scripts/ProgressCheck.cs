using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCheck : MonoBehaviour
{
    GameObject player;
    float distance = default;
    float startDistance = default;
    Image fillImage;
    float normalized;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fillImage = GameObject.Find("Canvas").transform.GetChild(0).GetChild(1).GetComponent<Image>();
        fillImage.fillAmount = 0;
        startDistance = Vector3.Distance(player.transform.position, transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);
            normalized = distance / startDistance;
            fillImage.fillAmount = normalized;
        }
    }
}
