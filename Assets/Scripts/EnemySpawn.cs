using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemy;
    public int number;
    private List<GameObject> spawned;

    private void Start() {
        for(int i = 0; i < number; i++) {
            Generate(i);
        }

    }

    void Generate(int i) {

        int x = Random.Range(-20, 20);
        int y = Random.Range(-20, 20);

        Vector3 target = new Vector3(x, y, 0);

        GameObject temp = Instantiate(enemy, target, Quaternion.identity);

        string tag = "Monster" + i;
        
        Debug.Log("spawned " + tag);

        temp.tag = tag;
        temp.transform.GetChild(0).gameObject.tag = tag;
    }

}
