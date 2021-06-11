using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static bool isPaused;
    private TitleScreen titleScreen;
    private GameOverScreen gameOverScreen;
    private PauseScreen pauseScreen;

    private void Awake()
    {
        instance = this;
        
        isPaused = false;
        Time.timeScale = 0.0f;

        titleScreen = FindObjectOfType<TitleScreen>();
        gameOverScreen = FindObjectOfType<GameOverScreen>();
        pauseScreen = FindObjectOfType<PauseScreen>();
        gameOverScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else if (!isPaused)
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        pauseScreen.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOverScreen.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        pauseScreen.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        titleScreen.gameObject.SetActive(false);
    }
}
