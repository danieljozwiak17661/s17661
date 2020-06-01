using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private bool movingRight = true;

    public bool groundDetected;
    public bool wallDetected;
    private bool playerDetected;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public Transform wallCheck;

    private KillManager KillManager;
    public bool killed;
    public int kills = 1;

    public int health;

    public float hitStartTime;
    public int hitDamage = 1;
    private float hitDuration;
    public Transform hitPos;
    public float hitRange;
    public LayerMask whatIsPlayer;


    private void Start()
    {
        KillManager = GameObject.Find("ScoreManager").GetComponent<KillManager>();
        killed = false;
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            killed = true;
            KillManager.IncrementScore(kills);
        }


        transform.Translate(Vector2.right * speed * Time.deltaTime);

        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, 2f, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, 1f, whatIsGround);
        playerDetected = Physics2D.Raycast(hitPos.position, transform.right, hitRange, whatIsPlayer);

     //flip
        if (!groundDetected || wallDetected)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        //hit
        if (playerDetected)
        {
            speed = 0;
            Hit();
        }
        else
        {
            speed = 5;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("killed");
    }
    public void Hit()
    {
        if (hitDuration <= -1)
        {
           
                Collider2D[] KillPlayer = Physics2D.OverlapCircleAll(hitPos.position, hitRange, whatIsPlayer);
                for (int i = 0; i < KillPlayer.Length; i++)
                {
                    KillPlayer[i].GetComponent<PlayerCore>().TakeDamage(hitDamage);
                }
            
            hitDuration = hitStartTime;
        }
        else
        {
            hitDuration -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitPos.position, hitRange);
    }
}
