using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class shooter : MonoBehaviour
{
    public GameObject droplet;
    public GameObject score;
    public GameObject SceneChanger;
    public Transform shootpoint;
    public float starttimebtwshots;
    private float timebtwshots;
    private int totalshotsleft;
    public int totalshots;
    public AudioSource spraysound;
    // Start is called before the first frame update
    void Start()
    {
        totalshotsleft = totalshots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timebtwshots <= 0 && totalshotsleft > 0)
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                Instantiate(droplet, shootpoint.position, transform.rotation);
                timebtwshots = starttimebtwshots;
                totalshotsleft--;
                spraysound.Play();
                score.GetComponent<UpdateScore>().UpdateShots(totalshotsleft);
            }
        }
        else
        {
            timebtwshots -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.CompareTag("SprayCan"))
        {

            collider.GetComponent<DestroyCan>().Vanish();
            totalshotsleft += 25;
            score.GetComponent<UpdateScore>().UpdateShots(totalshotsleft);

        }

        if (collider.CompareTag("InfoScroll"))
        {

            collider.GetComponent<DestroyScroll>().Vanish();
            Instantiate(SceneChanger, transform.position, Quaternion.identity);
        }

    }

   
}
