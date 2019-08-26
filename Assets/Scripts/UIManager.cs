using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject[] pauseObjects;
    public Text pauseText;

    // Use this for initialization
    void Start() {
        Time.timeScale = 1;
        Debug.Log("length : " + pauseObjects.Length);
        Resume();
    }

    // Update is called once per frame
    void Update() {

    }

    public void togglePause() {
        if (GlobalState.Instance.gameIsPaused) {
            Resume();
        } else {
            Pause();
        }
    }

    void Pause() {
        Time.timeScale = 0f;
        GlobalState.Instance.gameIsPaused = true;
        showPaused();
    }

    void Resume() {
        Time.timeScale = 1f;
        GlobalState.Instance.gameIsPaused = false;
        hidePaused();
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //shows objects with ShowOnPause tag
    public void showPaused() {
        pauseText.text = "Resume";
        foreach (GameObject g in pauseObjects) {
            Debug.Log(g.tag);
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused() {
        pauseText.text = "Pause";
        foreach (GameObject g in pauseObjects) {
            g.SetActive(false);
        }
    }
}

