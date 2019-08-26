using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalState : Singleton<GlobalState> {

    protected GlobalState() { }

    public bool alive = true;
    public bool gameIsPaused = false;
    public bool inMainMenu = false;

    public List<Transform> objects = new List<Transform>();

}
