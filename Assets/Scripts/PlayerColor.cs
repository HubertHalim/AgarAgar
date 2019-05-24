using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PlayerColor : MonoBehaviour {

    public List<Material> mats = new List<Material>();
    
    void Awake() {

        GetComponent<Renderer>().material = mats[Random.Range(0, mats.Count)];
    }

}
