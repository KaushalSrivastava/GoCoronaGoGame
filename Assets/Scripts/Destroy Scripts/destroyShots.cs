using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyShots : MonoBehaviour
{
    public AudioSource shotcollected;
    // Start is called before the first frame update
    public void Vanish()
    {
        Destroy(gameObject);
        shotcollected.Play();
    }
}
