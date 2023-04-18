using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private Renderer myRenderer = default;
    GameObject player;
    public bool isCollidePlayer;

    public GameObject particle;

    private SwerveInputSystem _swerveInputSystem;

    PlayerMovements playermove;

    public float health = 1000f;
    void Start()
    {
        myRenderer = transform.GetChild(1).GetComponent<Renderer>();
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
        player = GameObject.Find("Player");
        playermove = player.GetComponent<PlayerMovements>();
        isCollidePlayer = false;

    }
    void FixedUpdate()
    {
        // Friend karakterinin Playera çarptığında hareket kazandığı kod
        if (isCollidePlayer)
        {
            if (Input.GetMouseButton(0))
            {
                transform.position += Vector3.forward * Time.fixedDeltaTime * playermove.movementSpeed;
            }
            float swerveAmount = Time.deltaTime * playermove.swerveSpeed * _swerveInputSystem.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -playermove.maxSwerveAmount, playermove.maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);
            transform.position = new Vector3(transform.position.x, playermove.transform.position.y, transform.position.z);
        }
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "CollidedCompanion")
        {
            isCollidePlayer = true;
            myRenderer.material.color =new Color(0,0.32f,255);
        }
        if (col.gameObject.CompareTag("Obstacles"))
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Instantiate(particle, pos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
