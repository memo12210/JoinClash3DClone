using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public GameObject Camera;
    public GameObject[] Companions;
    public float speed = 5f;
    private bool playernearboss = false;
    public GameObject CompanionReference;



    private float distBetweenPlayerAndBoss;
    private bool inCutscene = false;
    public float Timer = 0.27f;
    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            inCutscene = true;
            Debug.Log("Cutscene");


        }
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        distBetweenPlayerAndBoss = Vector3.Distance(boss.transform.position, player.transform.position);

        Companions = GameObject.FindGameObjectsWithTag("CollidedCompanion");

        if(inCutscene == true)
        {
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            player.GetComponent<PlayerMovements>().enabled = false;
            player.GetComponent<PlayerAnimationControl>().enabled = false;
            if(playernearboss == false)
            {
            
            player.transform.position = Vector3.MoveTowards(player.transform.position, boss.transform.position, step);
            player.GetComponent<Animator>().SetBool("isRunning", true);

            }

            else
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, boss.transform.position, 0f);
                player.GetComponent<Animator>().SetBool("isRunning", false);
                player.GetComponent<Animator>().SetFloat("idleSpeed", 8f);
                player.GetComponent<Animator>().SetBool("Attack",true);
                boss.GetComponent<Animator>().SetBool("isPlayerReached", true);
                player.GetComponent<CollideDetectPlayer>().health -= 100 * Time.deltaTime * 0.27f;
                boss.GetComponent<BossHealth>().health -= 500f * Time.deltaTime * 0.27f;


                
            }

            for (int i = 0; i < Companions.Length; i++)
            {
                Companions[i].GetComponent<DetectPlayer>().enabled = false;
                Companions[i].GetComponent<CompanionAnimationControl>().enabled = false;
                if(playernearboss == false)
                {
                
                Companions[i].transform.position = Vector3.MoveTowards(Companions[i].transform.position, CompanionReference.transform.position,  step);
                Companions[i].GetComponent<Animator>().SetBool("isRunning", true);
                }

                else
                {
                    Companions[i].transform.position = Vector3.MoveTowards(Companions[i].transform.position, CompanionReference.transform.position, 0f);
                    Companions[i].GetComponent<Animator>().SetBool("isRunning", false);
                    Companions[i].GetComponent<Animator>().SetFloat("idleSpeed", 8f);
                    Companions[i].GetComponent<Animator>().SetBool("Attack",true);
                    Companions[i].GetComponent<DetectPlayer>().health -= 100 * Time.deltaTime * 0.27f;
                    boss.GetComponent<BossHealth>().health -= 500f * Time.deltaTime * 0.27f * i;
                    if(Companions[i].GetComponent<DetectPlayer>().health <= 0)
                    {
                        Destroy(Companions[i]);
                    }


                    if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
                    {
                        Companions[i].GetComponent<DetectPlayer>().health += 5000 * Time.deltaTime;
                        Companions[i].GetComponent<Animator>().SetBool("Attack",false);
                        Companions[i].GetComponent<Animator>().SetBool("Cheer", true);
                    }
                    
                }
            }

            if(distBetweenPlayerAndBoss <= 3f)
            {
                playernearboss = true;

            }


        }

        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            player.GetComponent<CollideDetectPlayer>().health += 5000 * Time.deltaTime;
            player.GetComponent<Animator>().SetBool("Attack",false);
            player.GetComponent<Animator>().SetBool("Cheer", true);
        }
    }


}
