using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Eat : MonoBehaviour {

    public string FoodTag;
    public float increase;
    public string EnemyTag;

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == FoodTag) {
            Debug.Log("eat");
            transform.localScale += new Vector3(increase, increase, increase);
            Destroy(other.gameObject);
        }
        Debug.Log("meet enemy " + other.gameObject.tag);
        if ((other.gameObject.tag.Length >= 7 && other.gameObject.tag.Substring(0, 7) == EnemyTag)) {
            Debug.Log("meet enemy " + other.gameObject.tag);
            Transform enemy = other.gameObject.transform;
            if (transform.localScale.magnitude >= enemy.localScale.magnitude) {
                transform.localScale += new Vector3(enemy.localScale.x / 3, enemy.localScale.y / 3, enemy.localScale.z / 3);
                Debug.Log("eat enemy");
            } else {
                Debug.Log("died");
                GlobalState.Instance.alive = false;
                Destroy(gameObject.transform.GetChild(0).gameObject);
                Destroy(gameObject);
            }
        }
    }
 
}
