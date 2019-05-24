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

        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        target.z = 0;

        Instantiate(food, target, Quaternion.identity);
    
    }

}
