using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour {

    public GameObject food;
    public float speed;

    void Start() {

        InvokeRepeating("Generate", 0, speed);
    }

    void Generate() {

        int x = Random.Range(-100, 100);
        int y = Random.Range(-100, 100);
         
        Vector3 target = new Vector3(x, y, 0);

        Instantiate(food, target, Quaternion.identity);
    }

    private void Update() {
        if (GlobalState.Instance.alive == false) {
            CancelInvoke();
        }
    }

}
