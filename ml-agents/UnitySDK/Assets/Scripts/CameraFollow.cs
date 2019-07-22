using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTank;
    public float cameraDistance = 30.0f;

    void Awake()
    {
        GetComponent<Camera>().orthographicSize = (Screen.height / 2) / cameraDistance;
    }

    private void Update() {
        Camera.main.orthographicSize = (float)Math.Sqrt(playerTank.localScale.magnitude) + 2.0f;
    }

    void FixedUpdate()
    {

        if (GlobalState.Instance.alive == true) {
            transform.position = new Vector3(playerTank.position.x, playerTank.position.y, -10.0f);
        }
    }
    
}
