using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject player;
    public Animator animator;

        void Update()
    {
        if (player.transform.position == new Vector3(transform.position.x,transform.position.y,72f))
        {
            Attack();

        }

    }

    void Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");
        // Detect Enemies in range of attack
        // Damage them
    }
}
