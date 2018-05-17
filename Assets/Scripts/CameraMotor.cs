﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 300, 1500);
    private Vector3 startRun = new Vector3(0, 269, -1071);
    private Vector3 currentAngle;
    // private Vector3 beginningAnimation = T

	// Use this for initialization
	void Start () {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = startRun - lookAt.position;
        currentAngle = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = lookAt.position + startOffset;

        // X
        moveVector.x = 0;

        // Y
        moveVector.y = Mathf.Clamp(moveVector.y, 200, 400);


        if (transition > 2.0f)
        {
            transform.position = moveVector;
        } else
        {
            // Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);


            transform.eulerAngles = new Vector3(
                Mathf.LerpAngle(currentAngle.x, currentAngle.x, transition),
                Mathf.LerpAngle(currentAngle.y, 0, transition),
                Mathf.LerpAngle(currentAngle.z, currentAngle.z, transition));

            transition += (Time.deltaTime / animationDuration) / 4;

            transform.LookAt(lookAt.position);
        }


    }
}
