using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScroll : MonoBehaviour
{

    public AudioSource scrollcollected;
    // Start is called before the first frame update
    public void Vanish()
    {
        Destroy(gameObject);
        scrollcollected.Play();
    }
}

