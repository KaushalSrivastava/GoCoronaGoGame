using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomenu : MonoBehaviour
{
    public int sceneno;
    public AudioSource click;

    public void ChangeScene()
    {
        click.Play();  
        SceneManager.LoadScene(sceneno);
    }

}
