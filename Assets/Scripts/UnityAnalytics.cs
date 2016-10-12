using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;

public enum AnalyticsEvent
{
    Launch,
    ShowAd,    
    Tutorial,
    Exit,

    GameStart,
    GameOver    
}

public static class CDAnalytics
{
    static Dictionary<AnalyticsEvent, string> parametersTypes = new Dictionary<AnalyticsEvent, string>();

    static CDAnalytics()
    {
        parametersTypes.Add(AnalyticsEvent.GameOver, "Scores");
        parametersTypes.Add(AnalyticsEvent.Exit, "Session Length");        
    }
	
	public static void Event(AnalyticsEvent ev, int? parameter = null)
    {        
        var result = Analytics.CustomEvent(ev.ToString(), parameter == null ? null : new Dictionary<string, object>
        {
            {parametersTypes[ev], parameter.GetValueOrDefault() }
        });
        Debug.Log(result);            
	}

}

