using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdatePills : MonoBehaviour
{
    private TextMeshProUGUI pillstext;
    // Start is called before the first frame update
    void Start()
    {
        pillstext = GetComponent<TextMeshProUGUI>();
        pillstext.text = "X " + GameDataManager.pills;
    }

    // Update is called once per frame
    public void UpdatePillsUI()
    {
        pillstext.text = "X " + GameDataManager.pills;
    }
}
