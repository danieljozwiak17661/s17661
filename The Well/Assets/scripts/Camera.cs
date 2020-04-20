using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    public float cameraDistance = 30f;
    // Start is called before the first frame update

     void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }
    void FixedUpdate ()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
