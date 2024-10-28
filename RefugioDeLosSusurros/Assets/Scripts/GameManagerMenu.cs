using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMenu : MonoBehaviour
{

    // M�todo para cambiar de escena
    public void ChangeScene(string sceneName)
    {
        Debug.Log("Cambiando a la escena: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    // M�todo para salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
        // Esto no har� nada en el editor de Unity, pero funcionar� en una build
    }

}
