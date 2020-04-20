using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour

{
    public float Speed;
    bool moveRight = true;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }
    void Update()
    {
        if (transform.position.x > -14f)
            moveRight = false;
        if (transform.position.x < -20f)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y);

    }
}
