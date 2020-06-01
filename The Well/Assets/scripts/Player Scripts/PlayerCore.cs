using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    private GameManager gameManager;

    public int playerHealth;
    public bool Angery;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }
    // Update is called once per frame

    public void TakeDamage(int hitDamage)
    {
        playerHealth -= hitDamage;
    }

}
