using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spitmotion : MonoBehaviour
{
    GameObject Target;
    private Rigidbody2D rb;
    private Vector3 directionToTarget;
    public float speed;
    public float lifetime;
    public GameObject destroyeffect;

    void Start()
    {
        Target = GameObject.Find("doctor body");
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(12, 9);
        Invoke("DestroySpit", lifetime);
    }

    void movespit()
    {
        if (Target != null)
        {
            directionToTarget = (Target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movespit();
    }
    void DestroySpit()
    {
        Instantiate(destroyeffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
