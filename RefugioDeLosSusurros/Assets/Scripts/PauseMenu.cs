using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isGamePause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePause = !isGamePause;
            PuaseGame();
        }
        
    }

    public void PuaseGame()
    {
        if (isGamePause)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePause = !isGamePause;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        // Obtiene el nombre de la escena actual y la recarga
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Debug.Log("Saliendo del juego..."); // Este mensaje se verá en el editor de Unity
        Application.Quit(); // Sale del juego
    }
}
