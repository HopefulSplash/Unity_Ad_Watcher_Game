using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour, IUnityAdsListener
{
    public static UnityAdManager instance;
    Action onFinishSuccess;
    public string gameId = "4378039";
    public string myPlacementIdR = "Rewarded_Android_AR";
    public string status = "NOT FINISHED";
    public bool loaded = false;
    void Start()
    {
        Destroy(instance);
        if (instance == null)
        {
            instance = this;
        }

        if (!Advertisement.isInitialized)
        {
            Advertisement.Initialize(gameId);
            instance = this;
            Advertisement.AddListener(this);
           
        }
        else
        {
        }

    }
    public void PlayRewardedAD(Action onFinish)
    {
        onFinishSuccess = onFinish;
        
        if (Advertisement.IsReady(myPlacementIdR))
        {
            status = "NA";
            Advertisement.Show(myPlacementIdR);
        }
        else
        {
        }
    }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
       
    }

    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {
       
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
    {
        
    }
    
    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            if (placementId == myPlacementIdR)
            {
                status = "Finished";
                instance.onFinishSuccess.Invoke();

            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            if (placementId == myPlacementIdR)
            {
                status = "Skipped";
                instance.onFinishSuccess.Invoke();

            }
        }
        else if (showResult == ShowResult.Failed)
        {
            if (placementId == myPlacementIdR)
            {
                status = "Failed";
                instance.onFinishSuccess.Invoke();

            }
        }
    }
}
