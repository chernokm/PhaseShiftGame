using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabDoor : MonoBehaviour
{
    Animator animator;
    bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
       if  (col.gameObject.tag == "Player")
        {
            doorOpen = true;
            Doors("Open");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (doorOpen)
            {
                doorOpen = false;
                Doors("Close");
            }
        }
    }

    void Doors(string direction)
    {
        animator.SetTrigger(direction);
    }
}
