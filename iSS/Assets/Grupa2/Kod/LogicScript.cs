using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public GameObject gameOverScreen;
    public GameManager gm;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gm.isPaused = false;
        gm.isOver = false;
    }

    public void QuitGame()
    {
        print("Quitting...");
        Application.Quit();
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gm.isOver = true;
        gameOverScreen.SetActive(true);
    }
}
