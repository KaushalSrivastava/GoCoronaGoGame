using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingspeed;
    public GameObject continueButton;
    public Animator textdisplayanim;
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
        textdisplayanim.SetTrigger("change");
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
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

    public void nextSentence()
    {
        click.Play();
        textdisplayanim.SetTrigger("change");
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "GOOD LUCK DR. SRIVASTAVA!";
            continueButton.SetActive(false);
            SceneManager.LoadScene(9);
        }
    }
    public void SkiptoGame()
    {
        click.Play();
        SceneManager.LoadScene(9);
    }

    }
