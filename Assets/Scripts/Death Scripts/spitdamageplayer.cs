using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spitdamageplayer : MonoBehaviour
{
    public int damagetoplayer;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collidedobj)
    {
        if (collidedobj.gameObject.CompareTag("Player"))
        {

            collidedobj.gameObject.GetComponent<playercontroller>().TakeDamage(damagetoplayer);
            
        }
        Destroy(gameObject);
    }
}