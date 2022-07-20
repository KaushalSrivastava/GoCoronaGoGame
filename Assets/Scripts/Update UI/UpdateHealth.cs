using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UpdateHealth : MonoBehaviour
{
    private TextMeshProUGUI health;
    public int initiallife;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<TextMeshProUGUI>();
        health.text = "X " + (initiallife + GameDataManager.extralife);
    }

    // Update is called once per frame
    public void UpdateHealthUI(int healthleft)
    {
        health.text = "X " + healthleft.ToString();
    }
}
