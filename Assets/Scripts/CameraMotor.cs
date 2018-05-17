using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 1.0f;
    private Vector3 animationOffset = new Vector3(0, 300, 1500);
    private Vector3 startRun = new Vector3(0, 269, -1071);
    // private Vector3 beginningAnimation = T

	// Use this for initialization
	void Start () {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = lookAt.position + startOffset;

        // X
        moveVector.x = 0;

        // Y
        moveVector.y = Mathf.Clamp(moveVector.y, 200, 400);

        if (Time.timeSinceLevelLoad > (animationDuration * 2))
        {
            transform.position = moveVector;
        } else if (Time.timeSinceLevelLoad > animationDuration)
        {
            transform.position = Vector3.Lerp(startRun, moveVector, transition);
            transition += Time.deltaTime / animationDuration;
        } else
        {
            // Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime / animationDuration;
            // transform.LookAt(lookAt.position - (Vector3.up * 5));
        }


    }
}
