using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text KillsText;
    public Text MostKillsText;
    public Text HightText;
    public Text BestHightText;
    public int kills;
    private int MostKills;
    public int Height;
    private int BestHeight;

    private void Awake()
    {
        //KILLS PART
        if (PlayerPrefs.HasKey(ScorePrefs.KILLS))
            kills = PlayerPrefs.GetInt(ScorePrefs.KILLS);
        else
        {
            kills = 0;
            PlayerPrefs.SetInt(ScorePrefs.KILLS, kills);
        }

        if (PlayerPrefs.HasKey(ScorePrefs.PREVIOUS_KILLS))
        {
            kills = PlayerPrefs.GetInt(ScorePrefs.PREVIOUS_KILLS);
            PlayerPrefs.SetInt(ScorePrefs.KILLS, kills);
        }
        else
        {
            PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_KILLS, kills);
        }

        if (PlayerPrefs.HasKey(ScorePrefs.MOST_KILLS))
            MostKills = PlayerPrefs.GetInt(ScorePrefs.MOST_KILLS);
        else
        {
            PlayerPrefs.SetInt(ScorePrefs.MOST_KILLS, 0);
        }

        //HEIGHT PART
        if (PlayerPrefs.HasKey(ScorePrefs.HEIGHT))
            Height = PlayerPrefs.GetInt(ScorePrefs.HEIGHT);
        else
        {
            Height = 0;
            PlayerPrefs.SetInt(ScorePrefs.HEIGHT, Height);
        }

        if (PlayerPrefs.HasKey(ScorePrefs.PREVIOUS_HEIGHT))
        {
            Height = PlayerPrefs.GetInt(ScorePrefs.PREVIOUS_HEIGHT);
            PlayerPrefs.SetInt(ScorePrefs.HEIGHT, Height);
        }
        else
        {
            PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_HEIGHT, Height);
        }

        if (PlayerPrefs.HasKey(ScorePrefs.BEST_HEIGHT))
            BestHeight = PlayerPrefs.GetInt(ScorePrefs.BEST_HEIGHT);
        else
        {
            PlayerPrefs.SetInt(ScorePrefs.BEST_HEIGHT, 0);
        }
    }



    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        //KILLS
        KillsText.text = "Kills:" + kills;
        MostKillsText.text = "Most Kills:" + MostKills;

        if (kills > MostKills)
        {
            PlayerPrefs.SetInt(ScorePrefs.MOST_KILLS, kills);
            MostKills = kills;
        }

        //HEIGHT
        HightText.text = "Height:" + Height;
        BestHightText.text = "Best Height:" + BestHeight;

        if (Height > BestHeight)
        {
            PlayerPrefs.SetInt(ScorePrefs.BEST_HEIGHT, Height);
            BestHeight = Height;
        }
    }
    public void IncrementScore(int k, int h)
    {
        kills += k;
        PlayerPrefs.SetInt(ScorePrefs.KILLS, kills);

        Height += h;
        PlayerPrefs.SetInt(ScorePrefs.HEIGHT, Height);

    }


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(ScorePrefs.MOST_KILLS, kills);
        PlayerPrefs.SetInt(ScorePrefs.KILLS, 0);
        PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_KILLS, 0);

        PlayerPrefs.SetInt(ScorePrefs.BEST_HEIGHT, Height);
        PlayerPrefs.SetInt(ScorePrefs.HEIGHT, 0);
        PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_HEIGHT, 0);
        PlayerPrefs.Save();
    }
}
