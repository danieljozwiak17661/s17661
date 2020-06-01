using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightManager : MonoBehaviour
{
    public Text HightText;
    public Text BestHightText;
    public int Height;
    private int BestHeight;

    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
            if (PlayerPrefs.HasKey(ScorePrefs.HEIGHT))
            Height = PlayerPrefs.GetInt(ScorePrefs.HEIGHT);
        else
        {
            Height = 0;
            PlayerPrefs.SetFloat(ScorePrefs.HEIGHT, Height);
        }

        if (PlayerPrefs.HasKey(ScorePrefs.PREVIOUS_HEIGHT))
        {
            Height = PlayerPrefs.GetInt(ScorePrefs.PREVIOUS_HEIGHT);
            PlayerPrefs.SetFloat(ScorePrefs.HEIGHT, Height);
        }
        else
        {
            PlayerPrefs.SetFloat(ScorePrefs.PREVIOUS_HEIGHT, Height);
        }

        if (PlayerPrefs.HasKey(ScorePrefs.BEST_HEIGHT))
            BestHeight = PlayerPrefs.GetInt(ScorePrefs.BEST_HEIGHT);
        else
        {
            PlayerPrefs.SetFloat(ScorePrefs.BEST_HEIGHT, 0);
        }
    }
    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        HightText.text = "Height:" + Height;
        BestHightText.text = "Best Height:" + BestHeight;

        if (Height > BestHeight)
        {
            PlayerPrefs.SetFloat(ScorePrefs.BEST_HEIGHT, Height);
            BestHeight = Height;
        }
    }
    public void IncrementScore (int h)
    {
        Height += h;
        PlayerPrefs.SetFloat(ScorePrefs.HEIGHT, Height);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat(ScorePrefs.BEST_HEIGHT, Height);
        PlayerPrefs.SetFloat(ScorePrefs.HEIGHT, 0);
        PlayerPrefs.SetFloat(ScorePrefs.PREVIOUS_HEIGHT, 0);
        PlayerPrefs.Save();
    }
}
