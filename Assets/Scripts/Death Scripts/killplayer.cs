using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killplayer : MonoBehaviour
{
    public int setplayerhealth;
    private void OnCollisionEnter2D(Collision2D collidedobj)
    {
        if (collidedobj.gameObject.CompareTag("Player"))
        {

            collidedobj.gameObject.GetComponent<playercontroller>().KillPlayer();

        }
    }
}
