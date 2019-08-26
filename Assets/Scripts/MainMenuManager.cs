using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    public Text highScore;

    private void Start() {
        highScore.text = GlobalState.Instance.highScore.ToString();
    }

    public void StartEasyGame() {
        GlobalState.Instance.difficulty = 0.08f;

        SceneManager.LoadScene("GameScene");
    }
    public void StartMediumGame() {
        GlobalState.Instance.difficulty = 0.1f;

        SceneManager.LoadScene("GameScene");
    }
    public void StartHardGame() {
        GlobalState.Instance.difficulty = 0.1321f;

        SceneManager.LoadScene("GameScene");
    }
}
