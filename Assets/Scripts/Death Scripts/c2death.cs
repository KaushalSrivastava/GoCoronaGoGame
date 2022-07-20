using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c2death : MonoBehaviour
{

    public int health;
    public int damagetoplayer;
    public GameObject Spray;
    public GameObject EnemyDeathEffect;
  
  

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(EnemyDeathEffect, transform.position, Quaternion.identity);
            Instantiate(Spray, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collidedobj)
    {
        if (collidedobj.gameObject.CompareTag("Player"))
        {
            Instantiate(EnemyDeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            collidedobj.gameObject.GetComponent<playercontroller>().TakeDamage(damagetoplayer);
            
        }


    }


}
