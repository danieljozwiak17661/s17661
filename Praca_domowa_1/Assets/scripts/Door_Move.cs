using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Move : MonoBehaviour
{
    Animator animator;
    bool door_Open;
    // Start is called before the first frame update
    void Start()
    {
        door_Open = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            door_Open = true;
            Debug.Log("Drzwi otwierają się");
            Doorcheck("Close");
        }
    }
        private void OnTriggerExit2D(Collider2D collision)
    {
        if(door_Open)
            {
                door_Open = false;
                Debug.Log("Drzwi zamykają się");
                Doorcheck("Close");
            }
    }
    void Doorcheck(string direction)
        {
            animator.SetTrigger(direction);
        }
}
