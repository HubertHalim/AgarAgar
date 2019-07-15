using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public List<Transform> objects = new List<Transform>();
    public string foodTag;
    public string playerTag;
    public string enemyTag;
    Vector2 direction;
    float timeCounter = 0;

    Transform GetClosestObject() {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = gameObject.transform.position;
        foreach (Transform potentialTarget in objects) {
            if(potentialTarget == null) {
                continue;
            }
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    // Update is called once per frame
    void FixedUpdate() {

        timeCounter += Time.deltaTime;
        Transform closest = GetClosestObject();
    
        Vector2 offset = new Vector2(0, 0);

        if (closest != null) {
            Debug.Log("closest object to " + gameObject.tag + " is " + closest.gameObject.tag);
            offset = closest.position - gameObject.transform.position;
        }

        if (closest != null && offset.magnitude > 1) {
            direction = Vector2.ClampMagnitude(offset, 1.0f);
        }

        if (gameObject != null) {
            if (closest == null || objects.Count == 0 || closest.transform.tag == "Untagged") {
                Wander();
            } else {
                if (closest.gameObject.tag == playerTag || (closest.gameObject.tag.Length >= 7 && closest.gameObject.tag.Substring(0, 7) == enemyTag)) {
                    if (closest.localScale.magnitude >= gameObject.transform.localScale.magnitude + 0.1) {
                        Escape(closest);
                    } else {
                        Chase(closest);
                    }
                } else if (closest.gameObject.tag == foodTag) {
                    FindFood(closest);
                }
            }
        }
        
    }

    void Escape(Transform threat) {
        Debug.Log("running away");
        direction.x = direction.x * -1;
        direction.y = direction.y * -1;
        MoveEnemy(direction);
    }

    void FindFood(Transform food) {
        Debug.Log("hungry");
        MoveEnemy(direction);
    }

    void Chase(Transform prey) {
        Debug.Log("hunting");
        MoveEnemy(direction);
    }

    void Wander() {
        Debug.Log("Dunno which way to go");
        float x = Mathf.Cos(timeCounter / 4);
        float y = Mathf.Sin(timeCounter / 4);
        direction = new Vector2(x, y);
        MoveEnemy(direction);
    }

    void MoveEnemy(Vector2 direction) {
        if (gameObject.transform.position.x > 100) {
            direction.x = -1;
        }
        if (gameObject.transform.position.x < -100) {
            direction.x = 1;
        }
        if (gameObject.transform.position.y > 100) {
            direction.y = -1;
        }
        if (gameObject.transform.position.y < -100) {
            direction.y = 1;
        }
        gameObject.transform.Translate(direction * speed * Time.deltaTime / (int)Math.Ceiling(gameObject.transform.transform.localScale.magnitude / 7));
    }
}
