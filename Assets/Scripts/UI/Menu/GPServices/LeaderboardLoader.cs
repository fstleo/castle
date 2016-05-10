using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class LeaderboardLoader : MonoBehaviour {

    const int LeaderboardSize = 6;

    IScore[] commonScores;
    IScore[] friendsScores;
    IUserProfile[] commonProfiles;
    IUserProfile[] friendsProfiles;

    LeaderboardPanel panel;

    void Awake()
    {
        panel = GetComponent<LeaderboardPanel>();
    }

    IEnumerator Start () {
        while (!Social.localUser.authenticated)
            yield return null;
        LoadLeaderboard();
        //if (friendsScores != null)
        //    panel.CreateLeaderboards(true, friendsScores, friendsProfiles);

	}

    private void LoadLeaderboard() {

        //IScore[] scores = new IScore[6];
        PlayGamesPlatform.Instance.LoadScores(
            GPGclass.leaderboard_scores,
            LeaderboardStart.PlayerCentered,
            12, LeaderboardCollection.Public, LeaderboardTimeSpan.AllTime,
            (data) =>
            {
                if (data.Valid)
                {
                    Log.Write("Scores loaded");
                    GetFormattedScores(data.Scores, data.PlayerScore.rank, CreateScores);
                }
                else
                    Log.Write("leadearboard data isn't valid");
            }
            );
    }

    private void CreateScores(IScore[] scores)
    {
        PlayGamesPlatform.Instance.LoadUsers(GetUserIDs(scores),
            (IUserProfile[] pfiles) =>
            {                
                Log.Write(pfiles.Length.ToString());
                if (scores != null)
                    panel.CreateLeaderboards(false, scores, pfiles);
                Log.Write("Leaderboards loaded");
            }
        );
    }

    private string[] GetUserIDs(IScore[] scores)
    {
        string[] IDs = new string[scores.Length];
        for (int i = 0; i < scores.Length; i++)
        {
            IDs[i] = scores[i].userID;
        }
        return IDs;
    }


    private void GetFormattedScores(IScore[] nearPlayerScores, int playerRank, Action<IScore[]> callback)
    {
        IScore[] resultScores = new IScore[6];
        if ((nearPlayerScores.Length < 6) || (playerRank < 6))
        {
            for (int i = 0; i < Mathf.Min(nearPlayerScores.Length, 6); i++)
                resultScores[i] = nearPlayerScores[i];
            callback(resultScores);
        }
        else
        {
            PlayGamesPlatform.Instance.LoadScores(
                GPGclass.leaderboard_scores,
                LeaderboardStart.TopScores,
                3, LeaderboardCollection.Public, LeaderboardTimeSpan.AllTime,
                (data) =>
                    {
                        if (data.Valid)
                        {
                            resultScores[0] = data.Scores[0];
                            resultScores[1] = data.Scores[1];
                            resultScores[2] = data.Scores[2];
                            resultScores[3] = nearPlayerScores[playerRank - 2];
                            resultScores[4] = nearPlayerScores[playerRank - 1];
                            resultScores[5] = nearPlayerScores[playerRank];
                            callback(resultScores);
                        }
                    }
            );

        }       
    }

    
}
