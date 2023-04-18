using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCompanionCheck : MonoBehaviour
{
    Animator anim;
    public GameObject particle = default;
   //bool triggered;
    public GameObject collidedCompanion = default;

    void Start()
    {
      anim =  GetComponent<Animator>();
    }
    
    void Update()
    {
        if(Vector3.Distance(transform.position, collidedCompanion.transform.position) < 20f)          
        {
            anim.SetTrigger("CompanionDetected");
            transform.position = Vector3.MoveTowards(transform.position, collidedCompanion.transform.position, 20f * Time.deltaTime);
            transform.LookAt(collidedCompanion.transform);
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag ("CollidedCompanion"))
        {
            Instantiate(particle, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z),Quaternion.identity);
            Instantiate(particle, new Vector3(collision.transform.position.x, collision.transform.position.y + 0.5f, collision.transform.position.z), Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}
