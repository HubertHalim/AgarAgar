using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalState : Singleton<GlobalState> {

    protected GlobalState() { }

    public int numOfEnemy = 5;

    public bool alive = true;

    public List<Transform> objects = new List<Transform>();

}
