using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Eat : MonoBehaviour {

    public string Tag;
    public float increase;

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == Tag) {
            transform.localScale += new Vector3(increase, increase, increase);
            Destroy(other.gameObject);
        } 
    }
 
}
