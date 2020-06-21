using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    private GameManager gameManager;

    public int playerHealth;
    public bool Angery;
    public Animator animator;
    public Transform Player;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        dead = false;
    }

     void Update()
    {
        Debug.Log(dead);
        if (playerHealth <= 0)
        {
            dead = true;
            //Destroy(gameObject);
            gameManager.GameOver();

        }
    }

    public void TakeDamage(int hitDamage)
    {
        playerHealth -= hitDamage;
        animator.SetTrigger("Death");
    }

}
