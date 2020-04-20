using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    public float delay;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Dissapear());
        }
    }        
    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

}
