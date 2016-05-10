using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class GPServices : MonoBehaviour {

    public static GPServices Instance;

    public delegate void AuthorizeActionDelegate();
    public static bool isAuthenticated
    {
        get;
        private set;
    }

    public static IUserProfile [] friends
    { get; private set; }

    public static string [] friendsIDs
    { get; private set; }
	
	void Awake ()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);       
    }

    public void Authenticate(AuthorizeActionDelegate callback)
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
       .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = false;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) => {
            isAuthenticated = success;
            if (success)
                callback();
            //Log.Write("GP authenticated");
            //if (success)
            //    LoadFriends();
        });
    }

    //void LoadFriends()
    //{
    //    friends = PlayGamesPlatform.Instance.GetFriends();
    //    friendsIDs = new string[friends.Length];
    //    for (int i = 0; i < friends.Length; i++)
    //    {
    //        friendsIDs[i] = friends[i].id;
    //    }
    //}
	
}
