using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    public float swerveSpeed = 0.5f;
    public float maxSwerveAmount = 1f;

    // private GameObject gameManager;

    public float movementSpeed;
    public float boostTimer;
    public bool boosting;
    public float jumpPow;
    public float gravityForce;

    Rigidbody rb;

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
        rb = GetComponent<Rigidbody>();
        movementSpeed = 10f;
        boostTimer = 0;
        boosting = false;
    }
    private void Update()
    {
        // Speed ve Jump Boost islemlerinin gerçekleştigi kısım
        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 3)
            {
                movementSpeed = 10f;
                boostTimer = 0;
                boosting = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, gravityForce, 0));

        // Playeri hareket ettiren kod
        if (Input.GetMouseButton(0))
        {
            transform.position += Vector3.forward * Time.fixedDeltaTime * movementSpeed;
        }
        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        // Eger SpeedBoosta çarptıysa boosting = true yapan statement
        if (other.CompareTag("SpeedBoost"))
        {
            boosting = true;
            movementSpeed = 20f;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("JumpBoost"))
        {
            rb.AddForce(new Vector3(0, jumpPow, 0), ForceMode.Impulse);
        }
    }
}
