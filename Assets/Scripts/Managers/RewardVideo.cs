using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardVideo : MonoBehaviour, IUnityAdsListener 
{
    string gameId = "3575310";
    string myPlacementId = "20Pills";
    public GameObject watchbutton;
    public GameObject neterrorbox;
    public GameObject noadsbox;
    public GameObject Loading;
    public AudioSource click;
    private bool adallowed = false;


    void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            Adinitialize();
        }
        else
        {
            netError();
        }
    }

    public void Adinitialize()
    {
            if (!Advertisement.isInitialized)
            {
                Advertisement.AddListener(this);
                Advertisement.Initialize(gameId);
            }
    }


        void FixedUpdate()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
          adallowed = true;
          Adinitialize();
        }
        else
        {
          adallowed = false;
        }

    }

   

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            getreward();
            Adinitialize();
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            Adinitialize();
        }
        else if (showResult == ShowResult.Failed)
        {           
            Adinitialize();
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
        noadsbox.SetActive(true);
        Adinitialize();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Adinitialize();
        // Optional actions to take when the end-users triggers an ad.
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
      
    }



    public void WatchAd()
    {
        click.Play();      
        if(adallowed)
            {
            if(Advertisement.IsReady())
               {
                    Advertisement.Show(myPlacementId);
               }
            else
              {
                watchbutton.SetActive(false);
                Loading.SetActive(true);
                Invoke("waitForAdLoad", 5f);
                noadsbox.SetActive(true);
            }

           }      
        else
        {
            netError();
        }
    }

    public void netError()
    {
       neterrorbox.SetActive(true);
    }

    public void hidenetError()
    {
        neterrorbox.SetActive(false);
    }
    public void hidenoads()
    {
        noadsbox.SetActive(false);
    }

    public void getreward()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            GameDataManager.pills += 20;
            GameDataManager.UpdatePills();
        }
    }

    public void waitForAdLoad()
    {
        Loading.SetActive(false);
        watchbutton.SetActive(true);
       
    }



}
