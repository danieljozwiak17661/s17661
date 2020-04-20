using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public GameObject bouncer;
    public float force;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            {
                bouncer.GetComponent<Rigidbody2D>().velocity = (new Vector2(0f, force));
            }

        }

    }

 


}
