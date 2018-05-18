using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public Animator anim;
    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 500.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 750.0f;

    private float animationDuration = 8.8f;

    private bool isDead = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (Time.timeSinceLevelLoad >= animationDuration)
        {
            anim.Play("Running");

            moveVector = Vector3.zero;

            if (controller.isGrounded)
            {
                verticalVelocity = -0.5f;
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }

            // X - Left and Right
            // moveVector.x = Input.acceleration.x * speed;
            moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

            // Y - Up and Down
            moveVector.y = verticalVelocity;

            //Z - Forward and Backward
            moveVector.z = speed;

            controller.Move(moveVector * Time.deltaTime);
        }
    }

    public void SetSpeed(float modifier)
    {
        speed = 500.0f + (100.0f * modifier) ;
    }

    // It is being called every time our capsule hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
            Death();
    }

    private void Death()
    {
        Debug.Log("Dead");
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}