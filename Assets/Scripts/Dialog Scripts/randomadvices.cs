using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomadvices : MonoBehaviour
{
    private Image img;
    public Sprite[] images;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = images[Random.Range(0, images.Length)];
    }

   
}
