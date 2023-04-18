using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerCollision : MonoBehaviour
{
    public bool isImgOn;
    public Image Image;
    public Button button1;

    public Button button2;
    public Text text;


    
    void Start()
    {
        Image.enabled = false;
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        text.gameObject.SetActive(false);

    }
    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Obstacles")
        {
            Destroy(gameObject);
            Image.enabled = true;
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(true);
            text.gameObject.SetActive(true);

            
            


        }

    }
}
