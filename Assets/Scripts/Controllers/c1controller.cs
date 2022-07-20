using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c1controller : MonoBehaviour
{
    public float speedc1;
    private Rigidbody2D rbc1;
    public Transform valleyCheckleftc1;
    public LayerMask whatIsGroundc1;
    public float checkradiusc1;
    private bool valleyinfrontc1 = false;
    private bool facingRightc1 = false;


    void Start()
    {
        rbc1 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //check for valley on both sides
        valleyinfrontc1 = Physics2D.OverlapCircle(valleyCheckleftc1.position, checkradiusc1, whatIsGroundc1);

        if (!valleyinfrontc1)
        {
            if (facingRightc1 == false)
            {
                //flip right
                transform.localEulerAngles = new Vector3(0, 0, 0);
                speedc1 *= -1;
                rbc1.velocity = new Vector2(speedc1, rbc1.velocity.y);
                facingRightc1 = !facingRightc1;
            }
            else
            {
                //flip left
                transform.localEulerAngles = new Vector3(0, 180, 0);
                speedc1 *= -1;
                rbc1.velocity = new Vector2(speedc1, rbc1.velocity.y);
                facingRightc1 = !facingRightc1;
            }

        }
        else
        {
            //keep crawling
            rbc1.velocity = new Vector2(speedc1, rbc1.velocity.y);
        }
    }


     
    }
