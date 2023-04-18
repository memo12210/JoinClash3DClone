using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeAnim : MonoBehaviour
{
    public float sec;
    Animator anim =default;

    public bool run;
    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!run)
        {
            sec -= 1 * Time.deltaTime;
            if (sec <= 0f)
            {
                anim.SetTrigger("Dance");
            }
        }
        if (run)
        {
            anim.SetTrigger("Run");
        }


    }
}
