using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changetoscreen : MonoBehaviour
{
    public int scenenumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }
    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scenenumber);
    }

}
