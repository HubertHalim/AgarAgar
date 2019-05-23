using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public Transform player;
    public float speed;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB; 
    private Vector2 direction;
    private Vector2 joystickD;

    public Transform innerCircle;
    public Transform outerCircle;
    
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            innerCircle.transform.position = pointA;
            outerCircle.transform.position = pointA;
            innerCircle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(Input.GetMouseButton(0)) {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        } else {
            touchStart = false;
        }
    }
    
    private void FixedUpdate() {
        if (touchStart) {
            Vector2 offset = pointB - pointA;
            joystickD = Vector2.ClampMagnitude(offset, 1.0f);
            if (offset.magnitude > 1) {
                direction = Vector2.ClampMagnitude(offset, 1.0f);
            }
            innerCircle.transform.position = new Vector2(pointA.x + joystickD.x, pointA.y + joystickD.y);
        } else {
            innerCircle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
        movePlayer(direction);
    }

    void movePlayer(Vector2 direction) {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
