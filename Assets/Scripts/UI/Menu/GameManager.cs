using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

    DateTime launchTime;

    void Start ()
    {
        CDAnalytics.Event(AnalyticsEvent.Launch);
        Application.targetFrameRate = 30;
        Application.LoadLevel(1);        
        launchTime = DateTime.Now;
    }

    void OnApplicationQuit()
    {
        CDAnalytics.Event(AnalyticsEvent.Exit, (DateTime.Now - launchTime).Minutes);
    }
	
}
