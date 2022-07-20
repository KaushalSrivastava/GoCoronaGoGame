using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private int prfLife = 20;
    private int prfDamage = 50;
    private int prfJumps = 100;
    public TextMeshProUGUI pillsDisplay;
    public TextMeshProUGUI lifeupgradeleft;
    public TextMeshProUGUI damageupgradeleft;
    public TextMeshProUGUI jumpupgradeleft;
    public GameObject errorMessage;
    public GameObject limitreached;
    public GameObject SuccessMessage;
    public AudioSource click;

    void Start()
    {
  //   resetPills();
     
    }
    void FixedUpdate()
    {
        pillsDisplay.text = GameDataManager.pills.ToString();
        switch (GameDataManager.extralife)
        {
            case 1: lifeupgradeleft.text = "4 Upgrades Left";
            break;
            case 2: lifeupgradeleft.text = "3 Upgrades Left";
            break;
            case 3: lifeupgradeleft.text = "2 Upgrades Left";
            break;
            case 4: lifeupgradeleft.text = "1 Upgrade Left";
            break;
            case 5: lifeupgradeleft.text = "Fully Upgraded !";
            break;
            default: lifeupgradeleft.text = "5 Upgrades Left";
            break;
        }
        switch (GameDataManager.extradamage)
        {
            case 2:
                damageupgradeleft.text = "1 Upgrade Left";
                break;
            case 4:
                damageupgradeleft.text = "Fully Upgraded !";
                break;
            default:
                damageupgradeleft.text = "2 Upgrades Left";
                break;
        }
        switch (GameDataManager.extrajump)
        {
            case 1:
                jumpupgradeleft.text = "Fully Upgraded !";
                break;
            default:
                jumpupgradeleft.text = "1 Upgrade Left";
                break;
        }

    }
    public void onelife()
    {
        click.Play();
        if (prfLife <= GameDataManager.pills && GameDataManager.extralife < 5)
        {
            GameDataManager.pills -= 20;
            GameDataManager.UpdatePills();
            GameDataManager.extralife++;
            GameDataManager.IncreaseExtraLife();
            SuccessMessage.SetActive(true);
        }
        else if(GameDataManager.extralife >= 5)
        {
            limitreached.SetActive(true);
        }
        else
        {
            errorMessage.SetActive(true);
        }
    }
    public void increaseDamage()
    {
        click.Play();
        if (prfDamage <= GameDataManager.pills && GameDataManager.extradamage < 4)
        {
            GameDataManager.pills -= 50;
            GameDataManager.UpdatePills();
            GameDataManager.IncreaseExtraDamage();
            SuccessMessage.SetActive(true);
        }
        else if (GameDataManager.extradamage >= 2)
        {
            limitreached.SetActive(true);
        }
        else
        {
            errorMessage.SetActive(true);
        }
    }
    public void doubleJumps()
    {
        click.Play();
        if (prfJumps <= GameDataManager.pills && GameDataManager.extrajump < 1)
        {
            GameDataManager.pills -= 100;
            GameDataManager.UpdatePills();
            GameDataManager.IncreaseExtraJump();
            SuccessMessage.SetActive(true);
        }
        else if (GameDataManager.extrajump >= 1)
        {
            limitreached.SetActive(true);
        }
        else
        {
            errorMessage.SetActive(true);
        }
    }
    public void resetPills()
    {
        GameDataManager.DeletePills();
        GameDataManager.DeleteExtraLife();
        GameDataManager.DeleteExtraDamage();
        GameDataManager.DeleteExtraJump();
    }
    public void hideError()
    {
        click.Play();
        errorMessage.SetActive(false);
    }
    public void hideLimitreached()
    {
        click.Play();
        limitreached.SetActive(false);
    }
    public void hideSuccess()
    {
        click.Play();
        SuccessMessage.SetActive(false);
    }
}
