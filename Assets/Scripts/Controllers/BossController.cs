using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Rigidbody2D rbboss;
    GameObject Target;
    public Transform mouth;
    public float speed;
    public float bossidletime;
    private Vector3 directionToTarget;
    private float smalldistance = 0.2f;
    private bool isFacingRight = false;
    private bool changer = false;
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
        if(Target != null)
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
            rbboss.velocity = new Vector2((directionToTarget.x * speed), (directionToTarget.y * speed) + smalldistance);
        }
        else
        {
            rbboss.velocity = new Vector2(rbboss.velocity.x, rbboss.velocity.y);
        }
    }


   IEnumerator switchmov()
    {  
        yield return new WaitForSeconds(bossidletime);
        if (changer)
        {
            Target = null;
            Instantiate(smallviruses, mouth.position, Quaternion.identity);
        }
        else
        {
            Target = GameObject.Find("doctor body");
            speed += 0.1f;
            smalldistance += 0.1f;
        }
        callchange();
    }

    void callchange()
    {
        changer = !changer;
        StartCoroutine(switchmov());
    }
}
