using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const int GROUND = 8; //nr layer z listy warst

    public float speed = 500;
    public float jumpSpeed = 400;
    public Animator animator;

    private Rigidbody2D rb;
    private float xDisplacement;
    private bool isGrounded;
    private bool facingRight;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    void Update(){
        xDisplacement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

        Flip(xDisplacement);

        animator.SetFloat("Szybkosc", Mathf.Abs(xDisplacement));

        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            isGrounded = false;

            animator.SetBool("Jumps", true);
        }
    }

    private void Flip(float xDisplacemet)
    {
        if (xDisplacement < 0 && !facingRight || xDisplacement > 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == GROUND)
            isGrounded = true;

            animator.SetBool("Jumps", false);
    }
}
