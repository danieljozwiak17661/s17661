using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Camera : MonoBehaviour
{
    public Transform Player;

    // Start is called before the first frame update

     void Awake()
    {

    }
    void FixedUpdate ()
    {
        if(Player != null)
                transform.position = new Vector3(Player.position.x,transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            if (Player.transform.position.y > 0)
            {
                if (Player.transform.position.y > transform.position.y)
                {
                    transform.position = new Vector3(transform.position.x, Player.position.y, transform.position.z);
                }
            }
        }
    }
}
