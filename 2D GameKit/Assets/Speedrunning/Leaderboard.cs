using UnityEngine.UI;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public string MemberID;
    public int ID;
    public int score;

    public int MaxScores;
    public TextMeshProUGUI[] IDs;
    public TextMeshProUGUI[] DisplayScore;

    public TextMeshProUGUI curerntScoreUI;
    public TextMeshProUGUI yourBestScore;

    

    public SaveTime saveTime;



    private void Start()
    {
        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("succes");
            }
            else
            {
                Debug.Log("failed");
            }
        });
        SetScore();
        SetPlayerScores();
        SubmitScore();
        ShowScores();
    }

    public void SetScore()
    {
        score = (int) (saveTime.GetTime() * 100);
        Debug.Log(score);
    }

    public void SetPlayerScores()
    {
        curerntScoreUI.text = ((float) score / 100).ToString();
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;
                for (int i = 0; i < scores.Length; i++)
                {
                    if(ID.ToString() == scores[i].member_id)
                    {
                        yourBestScore.text = ((float) scores[i].score / 100).ToString();

                    }
                }
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }


    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;
                for (int i = 0; i < scores.Length; i++)
                {
                    IDs[i].text = scores[i].member_id;
                    DisplayScore[i].text = ((float) scores[i].score / 100).ToString();
                    Debug.Log((float)scores[i].score / 100);

                }
                if (scores.Length < MaxScores)
                {
                    for (int i = scores.Length; i < MaxScores; i++)
                    {
                        IDs[i].text = "none";
                    }
                }
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            score += 1;
        }
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID, score, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("succes");
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }
}
