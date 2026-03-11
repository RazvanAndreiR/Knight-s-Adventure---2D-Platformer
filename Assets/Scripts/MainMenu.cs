using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        
        SceneManager.LoadSceneAsync("level 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void Ajutor()
    {
        SceneManager.LoadSceneAsync(6);
    }

    public void DespreJoc()
    {
        SceneManager.LoadSceneAsync(7);
    }    

    public void Controale()
    {
        SceneManager.LoadSceneAsync(8);
    }
}
