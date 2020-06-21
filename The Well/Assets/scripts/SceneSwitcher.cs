using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private KillManager KillManager;
    private HeightManager HeightManager;

    void Start()
    {
        GameObject g = GameObject.Find("ScoreManager");
        if (g != null)
        {
            KillManager = g.GetComponent<KillManager>();
            HeightManager = g.GetComponent<HeightManager>();
        }
    }

    public void LoadLevel(int i)
    {
        if (KillManager != null)
            PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_KILLS, KillManager.kills);
        if (HeightManager != null)
            PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_HEIGHT, HeightManager.Height);
        SceneManager.LoadScene("Level_" + i);
    }


}
