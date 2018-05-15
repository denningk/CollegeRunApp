using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public Animator anim;
    private CharacterController controller;

    private float speed = 500.0f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("Running");
        controller.Move(Vector3.forward * speed * Time.deltaTime);
    }
}