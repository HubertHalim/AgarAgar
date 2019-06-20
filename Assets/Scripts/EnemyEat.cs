using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyEat : MonoBehaviour {

    public string FoodTag;
    public float increase;
    public string PlayerTag;

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == FoodTag) {
            Debug.Log("eat");
            transform.localScale += new Vector3(increase, increase, increase);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == PlayerTag) {
            Debug.Log("player met");
            Transform player = other.gameObject.transform;
            if (transform.localScale.magnitude > player.localScale.magnitude) {
                transform.localScale += new Vector3(player.localScale.x / 3, player.localScale.y / 3, player.localScale.z / 3);
                Debug.Log("eat player");
            } else {
                Debug.Log("died");
                Destroy(gameObject.transform.GetChild(0).gameObject);
                Destroy(gameObject);
            }
        }
    }

}
