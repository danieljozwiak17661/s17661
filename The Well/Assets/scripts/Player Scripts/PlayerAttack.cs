using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackWait;
    public float startAttackWait;

    public Animator animator;


    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int damage;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (attackWait <= 0)
        {
            if (Input.GetKey(KeyCode.P))
            {
                Collider2D[] enemiesToKill = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToKill.Length; i++)
                {
                    enemiesToKill[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                animator.SetTrigger("PUNCH");
            }
            attackWait = startAttackWait;
        }
        else
        {
            attackWait -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
