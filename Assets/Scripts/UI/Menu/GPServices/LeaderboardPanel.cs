using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class LeaderboardPanel : MonoBehaviour {

    [SerializeField]
    Transform grid;
    [SerializeField]
    Transform friendsGrid;
    [SerializeField]
    GameObject panel;    

    public void CreateLeaderboards(bool isFriendLB, IScore[] scores, IUserProfile[] profiles)
    {
        for(int i = 0; i < scores.Length; i++)
        {
            if (scores[i] != null)
                LbRecord.Create(isFriendLB ? friendsGrid : grid, profiles[i], scores[i]);
            else
                LbRecord.CreateEmpty(isFriendLB ? friendsGrid : grid);
        }
    }

    public void On_ShowLeaderboard_Click()
    {
        if (!GPServices.isAuthenticated)
            GPServices.Instance.Authenticate(() => { PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGclass.leaderboard_scores); });
        else
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGclass.leaderboard_scores);

        //panel.SetActive(true);
    }

    public void On_ShowOnlyFriends_Click(bool value)
    {
        SoundPlayer.PlaySound("paper");
        friendsGrid.gameObject.SetActive(value);
        grid.gameObject.SetActive(!value);
    }

    public void On_HideLeaderboard_Click()
    {        
        panel.SetActive(false);
    }

    
}
