using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayfabManager : Singleton<PlayfabManager>
{


    public void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "9106F";
            PlayFabSettings.staticSettings.DeveloperSecretKey = "MY4XI7NCDOCOG9A68P1C1RUXJE7EUW83HU69SIHOY535T4QJPY";
        }

        var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);

    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        GetLeaderboard();
    }

    private void OnError(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }


    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate { StatisticName = "jump2d",  Value = score  }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    private void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("successful leaderboard sent");
    }


    public void GetLeaderboard()
    {
        var requestName = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = "Name",
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(requestName, (x) => { }, OnError);

        var request = new GetLeaderboardRequest
        {
            StatisticName = "jump2d",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }


    private void OnLeaderboardGet(GetLeaderboardResult result)
    {
        result.Leaderboard.ForEach(x =>
        {
            Debug.Log($"x position{x.Position} {x.PlayFabId} {x.StatValue}");
        });
    }





}
