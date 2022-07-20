using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("DropPlatform", 1f);
            Destroy(gameObject, 2f);

        }
    }

    // Update is called once per frame
   void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
