using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillManager : MonoBehaviour
{
    public Text KillsText;
    public Text MostKillsText;
    public int kills;
    private int MostKills;
    // Start is called before the first frame update
    void Start()
    {

    }
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
    }
    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }
    // Update is called once per frame
    void Update()
    {
        KillsText.text = "Kills:" + kills;
        MostKillsText.text = "Most Kills:" + MostKills;

        if (kills > MostKills)
        {
            PlayerPrefs.SetInt(ScorePrefs.MOST_KILLS, kills);
            MostKills = kills;
        }
    }
    public void IncrementScore(int k)
    {
        kills += k;
        PlayerPrefs.SetInt(ScorePrefs.KILLS, kills);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(ScorePrefs.MOST_KILLS, kills);
        PlayerPrefs.SetInt(ScorePrefs.KILLS, 0);
        PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_KILLS, 0);
        PlayerPrefs.Save();
    }
}
