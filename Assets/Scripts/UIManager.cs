using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject[] pauseObjects;
    public Text pauseText;
    public GameObject[] overObjects;
    public int timeLimit;
    public Text timer;
    public Text currentScore;
    public GameObject highScoreText;

    // Use this for initialization
    void Start() {
        Time.timeScale = 1;
        Debug.Log("length : " + pauseObjects.Length);
        Resume();
        hideGameOver();
        GlobalState.Instance.currentScore = 0;
        InvokeRepeating("UpdateTimer", 0, 1.0f);
    }

    void Update() {
        if (GlobalState.Instance.alive == false) {
            GameOver();
        }
        if (timeLimit == 0) {
            GameOver();
        }
        currentScore.text = GlobalState.Instance.currentScore.ToString();
    }

    void UpdateTimer() {
        timeLimit = timeLimit - 1;
        timer.text = (timeLimit/60).ToString("00") + ":" + (timeLimit%60).ToString("00");
    }

    public void togglePause() {
        if (GlobalState.Instance.gameIsPaused) {
            Resume();
        } else {
            Pause();
        }
    }

    public void toggleResume() {
        Resume(); 
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

    void GameOver() {
        Time.timeScale = 0f;
        if (GlobalState.Instance.highScore < GlobalState.Instance.currentScore) {
            Debug.Log(GlobalState.Instance.highScore + " vs " + GlobalState.Instance.currentScore);
            GlobalState.Instance.highScore = GlobalState.Instance.currentScore;
            highScoreText.SetActive(true);
        }
        showGameOver();
    }

    public void MainMenu() {
        SceneManager.LoadScene("MenuScene");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //shows objects with ShowOnPause tag
    public void showPaused() {
        pauseText.text = "Resume";
        foreach (GameObject g in pauseObjects) {
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

    public void showGameOver() {
        foreach (GameObject g in overObjects) {
            g.SetActive(true);
        }
    }

    public void hideGameOver() {
        foreach (GameObject g in overObjects) {
            g.SetActive(false);
        }
        highScoreText.SetActive(false);
    }
}

