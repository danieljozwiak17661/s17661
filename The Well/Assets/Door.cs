using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int levelToLoad;
    private SceneSwitcher sceneSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sceneSwitcher.LoadLevel(levelToLoad);
        }
    }

}
