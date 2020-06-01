using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text gameOverText;
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PlayerPrefs.SetInt(ScorePrefs.KILLS, 0);
                PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_KILLS, 0);
                PlayerPrefs.SetInt(ScorePrefs.HEIGHT, 0);
                PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_HEIGHT, 0);
                SceneManager.LoadScene("Menu");
            }
        }
    }
    public void GameOver()
    {
        gameOverText.text = "YOU ARE DEAD - press1 to retry";
        gameOver = true;
        PlayerPrefs.SetInt(ScorePrefs.KILLS, PlayerPrefs.GetInt(ScorePrefs.PREVIOUS_KILLS));
        PlayerPrefs.SetInt(ScorePrefs.HEIGHT, PlayerPrefs.GetInt(ScorePrefs.PREVIOUS_HEIGHT));
    }

}
