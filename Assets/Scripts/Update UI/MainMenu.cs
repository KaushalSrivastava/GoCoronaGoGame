using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource click;
    public void PlayGame()
    {
        click.Play();
        SceneManager.LoadScene(1);
    }
    public void BackToMainMenu()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }
    public void GotoShop()
    {
        click.Play();
        SceneManager.LoadScene(11);
    }
    public void PlayBoss()
    {
        click.Play();
        SceneManager.LoadScene(5);
    }
    public void QuitGame()
    {
        click.Play();
        Application.Quit();
    }
   
}
