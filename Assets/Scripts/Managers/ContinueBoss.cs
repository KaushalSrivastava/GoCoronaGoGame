using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueBoss : MonoBehaviour
{
    public GameObject ContinueBox;
    public GameObject NoPills;
    GameObject Doctor;
    // Start is called before the first frame update
    void Start()
    {
        Doctor = GameObject.Find("doctor body");
    }

    void Update()
    {
        if (Doctor == null && !(ContinueBox.activeSelf))
        {

            Invoke("setactivecontinue", 1f);

        }
    }

    public void setactivecontinue()
    {
        ContinueBox.SetActive(true);
    }

    public void continuestage()
    {
        if (GameDataManager.pills >= 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameDataManager.pills -= 10;
            GameDataManager.UpdatePills();
        }
        else
        {
            NoPills.SetActive(true);
        }
    }

    public void hideNoPills()
    {
        NoPills.SetActive(false);
    }

    public void quitstage()
    {
        SceneManager.LoadScene(7);
    }

}
