using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class UnityAd : MonoBehaviour {

    bool needShow = false;
    bool threeDaysCheck
    {
        get
        {
            if (PlayerPrefs.HasKey("firstappstartticks"))
            {
                long fisrtStartTicks = long.Parse(PlayerPrefs.GetString("firstappstartticks"));
                long todayTicks = DateTime.Today.Ticks;
                return todayTicks - fisrtStartTicks > 3 * TimeSpan.TicksPerDay;
            }
            else
            {
                PlayerPrefs.SetString("firstappstartticks", DateTime.Today.Ticks.ToString());
                return false;
            }
                
        }
    }

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
         if ((num == 2) && (threeDaysCheck))
        {
            needShow = true;
        }
    }
	
	public void ShowAd()
    {        
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

}
