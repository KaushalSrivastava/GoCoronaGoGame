using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c2controller : MonoBehaviour
{
    private Rigidbody2D rbc2;
    GameObject Target;
    private float speed;
    public float minSpeed;
    public float maxSpeed;
    private float vspeed;
    private Vector3 directionToTarget;
    public float RangeCheck;
    private bool isFacingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("doctor body");
        rbc2 = GetComponent<Rigidbody2D>();
        speed = Random.Range(minSpeed, maxSpeed);
        Physics2D.IgnoreLayerCollision(12, 8);
        Physics2D.IgnoreLayerCollision(12, 9);
        Physics2D.IgnoreLayerCollision(12, 11);
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) < RangeCheck)
            {
                movec2();
            }
        }
    }

    void movec2()
    {
        if (Target != null)
        {
            directionToTarget = (Target.transform.position - transform.position).normalized;
            if (directionToTarget.x < 0 && isFacingRight == true)
            {
                flip();
            }
            if (directionToTarget.x > 0 && isFacingRight == false)
            {
                flip();
            }
            rbc2.velocity = new Vector2(directionToTarget.x * speed, directionToTarget.y * speed);
        }
        else
        {
            rbc2.velocity = Vector3.zero;
        }
    }

    void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        
    }
}
