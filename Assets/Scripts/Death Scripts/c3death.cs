using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c3death : MonoBehaviour
{

    public int health;
    public int damagetoplayer;
    public GameObject EnemyDeathEffect;
    public GameObject Pill;
    public AudioSource coronadeathsound;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(EnemyDeathEffect, transform.position, Quaternion.identity);
            Instantiate(Pill, transform.position, Quaternion.identity);
            Destroy(gameObject);
            coronadeathsound.Play();
            
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
