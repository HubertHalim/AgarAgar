using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance;
    public float difficulty;
    public int highscore;

    // Start is called before the first frame update
    void Awake()
    {
        this.InstantiateController();
    }

    // Update is called once per frame
    private void InstantiateController()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(this.gameObject);
        }
    }
}
