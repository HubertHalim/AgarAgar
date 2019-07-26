using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTank;
    public float cameraDistance = 30.0f;
    public float minimumHeight = -10.0f;
    void Awake()
    {
        GetComponent<Camera>().orthographicSize = (Screen.height / 2) / cameraDistance;
    }

    private void Update() {
        float newSize = (float)Math.Pow(playerTank.localScale.magnitude, 0.75) * 1.5f;
        if (newSize > Camera.main.orthographicSize)
        {
            Camera.main.orthographicSize = newSize;
            minimumHeight = -newSize;
        }
    }

    void FixedUpdate()
    {

        if (GlobalState.Instance.alive == true) {
            transform.position = new Vector3(playerTank.position.x, playerTank.position.y, minimumHeight);
        }
    }
    
}
