using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDataManager : MonoBehaviour
{
    public const string Pills = "Pills";
    public static int pills = 0;

    public const string ExtraLife = "ExtraLife";
    public static int extralife = 0;

    public const string ExtraDamage = "ExtraDamage";
    public static int extradamage = 0;

    public const string ExtraJump = "ExtraJump";
    public static int extrajump = 0;

    static GameObject pillstext;

    // Start is called before the first frame update
    void Start()
    {
       
        pills = PlayerPrefs.GetInt("Pills");
        extralife = PlayerPrefs.GetInt("ExtraLife");
        extradamage = PlayerPrefs.GetInt("ExtraDamage");
        extrajump = PlayerPrefs.GetInt("ExtraJump");
        pillstext = GameObject.Find("PillsCount");
        if (pillstext != null)
        {
            pillstext.GetComponent<UpdatePills>().UpdatePillsUI();
        }
    }

    
    public static void UpdatePills()
    {
        PlayerPrefs.SetInt("Pills", pills);
        PlayerPrefs.Save();
        if (pillstext != null)
        {
            pillstext.GetComponent<UpdatePills>().UpdatePillsUI();
        }
    }

    public static void DeletePills()
    {
        pills = 0;
        PlayerPrefs.SetInt("Pills", pills);
        UpdatePills();      
    }

    public static void IncreaseExtraLife()
    {
        
        PlayerPrefs.SetInt("ExtraLife", extralife);
        PlayerPrefs.Save();
    }
    public static void DeleteExtraLife()
    {
        extralife = 0;
        PlayerPrefs.SetInt("ExtraLife", extralife);
        PlayerPrefs.Save();
    }

    public static void IncreaseExtraDamage()
    {
        extradamage += 2;
        PlayerPrefs.SetInt("ExtraDamage", extradamage);
        PlayerPrefs.Save();
    }
    public static void DeleteExtraDamage()
    {
        extradamage = 0;
        PlayerPrefs.SetInt("ExtraDamage", extradamage);
        PlayerPrefs.Save();
    }
    public static void IncreaseExtraJump()
    {
        extrajump++;
        PlayerPrefs.SetInt("ExtraJump", extrajump);
        PlayerPrefs.Save();
    }
    public static void DeleteExtraJump()
    {
        extrajump = 0;
        PlayerPrefs.SetInt("ExtraJump", extrajump);
        PlayerPrefs.Save();
    }


}
