using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dialogScriptBoss : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingspeed;
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Type());
        
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            nextSentence();
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
    }

    void nextSentence()
    {
        
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }
    public void SkiptoGame()
    {
        click.Play();
        SceneManager.LoadScene(6);
    }

}
