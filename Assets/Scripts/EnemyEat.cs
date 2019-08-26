using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyEat : MonoBehaviour {

    public string FoodTag;
    public float increase = GlobalState.Instance.difficulty;
    public string PlayerTag;
    public string EnemyTag;
    EnemyMove script;

    private void Start() {
        script = transform.GetComponent<EnemyMove>();
    }

    private void OnTriggerEnter(Collider other) {

        Debug.Log("lai liao");
        float mag;
        if (other.transform.localScale.magnitude <= gameObject.transform.localScale.magnitude) {
            mag = gameObject.transform.localScale.magnitude;
        } else {
            mag = other.transform.localScale.magnitude;
        }
        if ((other.gameObject.transform.position - gameObject.transform.position).magnitude < mag) {
            Debug.Log(other.gameObject.tag);
            if (other.gameObject.tag == FoodTag) {
                Debug.Log("monster eats food");
                transform.localScale += new Vector3(increase, increase, increase);
                script.objects.Remove(other.transform);
                Destroy(other.gameObject);
            }

            if (other.gameObject.tag == PlayerTag || (other.gameObject.tag.Length >= 7 && other.gameObject.tag.Substring(0, 7) == EnemyTag)) {
                Debug.Log("monster meets potential prey");
                Transform player = other.gameObject.transform;
                if (transform.localScale.magnitude > player.localScale.magnitude) {
                    transform.localScale += new Vector3(player.localScale.x / 3, player.localScale.y / 3, player.localScale.z / 3);
                    script.objects.Remove(other.transform);
                    Debug.Log("monster eats prey");
                } else {
                    Debug.Log("monster died");
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}
