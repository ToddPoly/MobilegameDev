using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SetScore(int score)
    {
        scoreDisplay.text = "Final Score: " + score.ToString();
    }
}
