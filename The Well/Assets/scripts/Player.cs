using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    public float jumpForce;

    public Animator animator;

    public float time;

    bool isGrounded = false;
    public Transform isGroundedCheck;
    public float groundCheckRadius;
    public LayerMask theground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();

        //flip
        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -2;
        }
        if (Input.GetAxis("Horizontal") >= 0)
        {
            characterScale.x = 2;
        }
        transform.localScale = characterScale;
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float moveBy = x * speed;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        animator.SetFloat("Szybkosc", Mathf.Abs(x));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("Jumps", true);
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedCheck.position, groundCheckRadius, theground);
        if (collider != null)
        {
                isGrounded = true;
                animator.SetBool("Jumps", false);
        }
        else
        {
            isGrounded = false;
        }
        
    }
}