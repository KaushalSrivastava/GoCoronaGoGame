using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMotionVertical : MonoBehaviour
{
    public float speed;
    public float distance;
    private float distanceleft;
    private Vector3 temppos;


    // Start is called before the first frame update
    void Start()
    {
        temppos = transform.position;
        distanceleft = distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (distanceleft > 0)
        {
            temppos.y += speed;
            transform.position = temppos;
            distanceleft--;

        }
        else
        {
            speed = -speed;
            distanceleft = distance;
        }
    }
    private void OnCollisionEnter2D(Collision2D collidedobj)
    {
        if (collidedobj.gameObject.CompareTag("Player"))
        {

            collidedobj.gameObject.transform.SetParent(transform);

        }
    }
    private void OnCollisionExit2D(Collision2D collidedobj)
    {
        if (collidedobj.gameObject.CompareTag("Player"))
        {

            collidedobj.gameObject.transform.SetParent(null);

        }
    }


}
