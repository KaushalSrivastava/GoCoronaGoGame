using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spitcontroller : MonoBehaviour
{
    public Transform spitpoint;
    public float spitinterval;
    public GameObject spit;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(spitting());
    }

    // Update is called once per frame
    IEnumerator spitting()
    {
        yield return new WaitForSeconds(spitinterval);
        animator.SetTrigger("spit");
        Instantiate(spit, spitpoint.position, Quaternion.identity);
        recallspit();
    }
    void recallspit()
    {
        StartCoroutine(spitting());
    }
}
