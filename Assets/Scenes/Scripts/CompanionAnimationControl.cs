using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAnimationControl : MonoBehaviour
{
    public bool isCollidedPlayer;
    private Animator anim;

    void Start()
    {
        isCollidedPlayer = false;
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "CollidedCompanion")
        {
            isCollidedPlayer = true;
            anim.SetBool("isRunning",true);
        }

    

    }

    void Update()
    {
        if(isCollidedPlayer == true)
        {
            gameObject.tag = "CollidedCompanion";
            anim.SetBool("isRunning",true);
        }

        if(isCollidedPlayer == true && Input.touchCount <= 0)
        {
            anim.SetBool("isRunning",false);

        }
    }
}
