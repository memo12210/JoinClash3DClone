using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            anim.SetBool("isRunning", true);
        }

        if(Input.touchCount <= 0)
        {
            anim.SetBool("isRunning", false);
        }

    }
}
