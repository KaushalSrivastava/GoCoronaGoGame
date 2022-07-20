using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundmotion : MonoBehaviour
{
    private Rigidbody2D rbboss;
    // Start is called before the first frame update
    void Start()
    {
        rbboss = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        rbboss.velocity = new Vector2(-0.5f, rbboss.velocity.y);
    }
}
