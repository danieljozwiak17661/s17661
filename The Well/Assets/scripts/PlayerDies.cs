using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDies : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        print("Died");
        animator.SetTrigger("Death");
    }

    // Update is called once per frame
    void Update()
    {

    }

}
