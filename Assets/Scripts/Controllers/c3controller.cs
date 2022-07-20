using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c3controller : MonoBehaviour
{
    private Rigidbody2D rbboss;
    GameObject Target;
    public Transform mouth;
    public float speed;
    public float bossidletime;
    private Vector3 directionToTarget;
    private bool isFacingRight = false;
    private bool changer = true;
    public GameObject smallviruses;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("doctor body");
        rbboss = GetComponent<Rigidbody2D>();
        StartCoroutine(switchmov());
    }

    void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

    }

    // Update is called once per frame
    void Update()
    {
        moveBoss();
    }


    void moveBoss()
    {
        if (Target != null)
        {
         
            rbboss.velocity = new Vector2((directionToTarget.x * speed), rbboss.velocity.y);
            directionToTarget = (Target.transform.position - transform.position).normalized;
            if (directionToTarget.x < 0 && isFacingRight == true)
            {
                flip();
              
            }
            if (directionToTarget.x > 0 && isFacingRight == false)
            {
                flip();
               
            }
        }    
    }


    IEnumerator switchmov()
    {
        yield return new WaitForSeconds(bossidletime);
        if (changer)
        {
            Instantiate(smallviruses, mouth.position, Quaternion.identity);
        }
        callchange();
    }

    void callchange()
    {
        StartCoroutine(switchmov());
    }
}
