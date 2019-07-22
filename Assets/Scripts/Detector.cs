using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    EnemyMove script;

    private void Start() {
        script = transform.parent.GetComponent<EnemyMove>();        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == gameObject.transform.parent.tag) {
            Debug.Log("false alarm");
            return;
        }
        Debug.Log("object enters");
        script.objects.Add(other.transform);
        //GlobalState.Instance.objects.Add(other.transform);
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("object " + other.transform.tag + " escapes");
        script.objects.Remove(other.transform);
        //GlobalState.Instance.objects.Add(other.transform);
    }
}
