using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour
{
    public void StartEasyGame()
    {
        GlobalState.Instance.highScore = 0;
        GlobalState.Instance.difficulty = 0.4f;

        SceneManager.LoadScene("SampleScene");
    }
    public void StartMediumGame()
    {
        GlobalState.Instance.highScore = 0;
        GlobalState.Instance.difficulty = 0.5f;

        SceneManager.LoadScene("SampleScene");
    }
    public void StartHardGame()
    {
        GlobalState.Instance.highScore = 0;
        GlobalState.Instance.difficulty = 0.9f;

        SceneManager.LoadScene("SampleScene");
    }

}
