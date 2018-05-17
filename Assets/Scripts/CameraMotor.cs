using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 startRun = new Vector3(0, 269, -800);
    private Vector3 startingVector;
    private Vector3 faceOffset = new Vector3(0, 150, 0);
    private Vector3 center;

    // private Vector3 beginningAnimation = T

	// Use this for initialization
	void Start () {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        center = lookAt.position + faceOffset;
        startOffset = startRun - lookAt.position;
        startingVector = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = lookAt.position + startOffset;

        // X
        moveVector.x = 0;

        // Y
        moveVector.y = Mathf.Clamp(moveVector.y, 200, 400);


        if (transition > 1.0f)
        {
            transform.position = moveVector;
        } else
        {
            // Animation at the start of the game
            transform.position = Vector3.Lerp(startingVector, startRun, transition);

            transition += (Time.deltaTime / animationDuration) / 3;

            transform.LookAt(center);
        }


    }
}
