using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class UnityAd : MonoBehaviour {

    bool needShow = false;

	void Start ()
    {        
        DontDestroyOnLoad(gameObject);
    }
    
    void OnLevelWasLoaded(int num)
    {
        if (needShow)
        {
            ShowAd();
            needShow = false;
        }
        if (num == 2)
        {
            needShow = true;
        }
    }
	
	public void ShowAd()
    {                
        if (Advertisement.IsReady())
        {
            CDAnalytics.Event(AnalyticsEvent.ShowAd);
            Advertisement.Show();
        }
    }
}
