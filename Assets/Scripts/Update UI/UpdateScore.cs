using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UpdateScore : MonoBehaviour
{
   private TextMeshProUGUI sprays;
    
    // Start is called before the first frame update
    void Start()
    {
        sprays = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    public void UpdateShots(int shotsleft)
    {
        sprays.text = "X " + shotsleft.ToString();
    }
}
