using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using System;

public class EnemyAgent : Agent {

    public float increase;

    private void Start() {
        AgentReset();
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("something hits " + other.gameObject.tag);
        if (other.gameObject.tag == "Player" || other.gameObject.tag.Substring(0, 7) == "Monster") {
            //Debug.Log("AI monster touch sth");
            Transform player = other.gameObject.transform;
            if (transform.localScale.magnitude > player.localScale.magnitude) {
                transform.localScale += new Vector3(player.localScale.x / 3, player.localScale.y / 3, player.localScale.z / 3);
                AddReward(1.0f);
                //Debug.Log("AI monster eats prey");
            } else {
                //Debug.Log("AI monster died");
                Destroy(gameObject.transform.GetChild(0).gameObject);
                Destroy(gameObject);
                Done();
                AddReward(-1.0f);
            } 
        } else if (other.gameObject.tag == "Food") {
            transform.localScale += new Vector3(increase, increase, increase);
            Destroy(other.gameObject);
            AddReward(0.1f);
        } 
    }

    Vector3 direction = Vector3.zero;

    public override void AgentAction(float[] vectorAction, string textAction) {
        base.AgentAction(vectorAction, textAction);
        direction.x = vectorAction[0];
        direction.y = vectorAction[1];
        direction.z = 0;

        GetComponent<Rigidbody>().velocity = direction * 5 * Time.deltaTime / (int)Math.Ceiling(transform.transform.localScale.magnitude / 10);
        //transform.Translate(direction * 5 * Time.deltaTime / (int)Math.Ceiling(transform.transform.localScale.magnitude / 10));

        if (GetStepCount() > 998) {
            Done();
            AddReward(-1.0f);
        }
        if (GlobalState.Instance.numOfEnemy == 0) {
            Done();
            AddReward(1.0f);
        }
    }

}
