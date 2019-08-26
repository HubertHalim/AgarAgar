using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour {

    public Transform player; // Player Object
    public float speed; // Player Speed
    private bool touchStart = false; // Whether player is touching the screen
    private Vector2 pointA; // Position where player start to touch the screen
    private Vector2 pointB; // Position of the player's finger at the end
    private Vector2 direction; // Direction of movement
    private Vector2 joystickD; // Direction of joystick

    public Transform innerCircle; // Inner circle object - touch point
    public Transform outerCircle; // Outer circle object - threshold
    public float decrease;
    private float size;

    private void Start() {
        // Whether player is alive or not
        GlobalState.Instance.alive = true;
    }

    void Update() {

        size = Camera.main.orthographicSize/5f; // Relative size of the joystick compared to screen scale
        innerCircle.localScale = new Vector3(size, size, size);
        outerCircle.localScale = new Vector3(size, size, size);

        if (GlobalState.Instance.alive == true && GlobalState.Instance.gameIsPaused == false) {
            if (player.transform.localScale.magnitude > 5) {
                Debug.Log("decreasing");

                player.transform.localScale -= new Vector3(decrease, decrease, decrease);
            }
            if (Input.GetMouseButtonDown(0)) {
                
                // Get position where the player touches the screen
                pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
                   
                // Display joystick at the place where player first touch the screen
                innerCircle.transform.position = pointA;
                outerCircle.transform.position = pointA;
                innerCircle.GetComponent<SpriteRenderer>().enabled = true;
                outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (Input.GetMouseButton(0)) {
                
                //Track player's finger movement as long as finger is on the screen
                touchStart = true;
                pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            } else {
                touchStart = false;
            }
        } 
        if (GlobalState.Instance.gameIsPaused == true) {
            innerCircle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    
    private void FixedUpdate() {
        if (GlobalState.Instance.alive == true) {
            if (touchStart) {
                // Get the vector from A to B
                Vector2 offset = pointB - pointA;
                // Direction of joystick movement limiting it to the size
                joystickD = Vector2.ClampMagnitude(offset, size);
                if (offset.magnitude > 1) {
                    // Cap the joystick movement to the size 
                    direction = Vector2.ClampMagnitude(offset, size);
                }
                // Move joystick to new position
                innerCircle.transform.position = new Vector2(pointA.x + joystickD.x, pointA.y + joystickD.y);
            } else {
                innerCircle.GetComponent<SpriteRenderer>().enabled = false;
                outerCircle.GetComponent<SpriteRenderer>().enabled = false;
            }
            // Move player in the direction specified in the {direction} vector
            movePlayer(direction);
        }
    }

    void movePlayer(Vector2 direction) {
        if (player.position.x > 100) {
            direction.x = -1;
        }
        if (player.position.x < -100) {
            direction.x = 1;
        }
        if (player.position.y > 100) {
            direction.y = -1;
        }
        if (player.position.y < -100) {
            direction.y = 1;
        }
        player.Translate(direction * speed * Time.deltaTime / (int)Math.Ceiling(player.transform.localScale.magnitude / 10));
        innerCircle.Translate(direction * speed * Time.deltaTime / (int)Math.Ceiling(player.transform.localScale.magnitude / 10));
        outerCircle.Translate(direction * speed * Time.deltaTime / (int)Math.Ceiling(player.transform.localScale.magnitude / 10));
        pointA = outerCircle.transform.position;
    }
}
