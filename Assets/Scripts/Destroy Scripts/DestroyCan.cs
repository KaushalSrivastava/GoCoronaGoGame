using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCan : MonoBehaviour
{
    public AudioSource spraycollected;
    // Start is called before the first frame update
 public void Vanish()
    {
        Destroy(gameObject);
        spraycollected.Play();
    }
}
