using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorEvents : MonoBehaviour
{

    public GameObject hackingTerminalTrigger;
    public GameObject hackingTerminalKeycardTrigger;
    public GameObject newLabDoorTrigger;
    public GameObject gardenDoorTrigger;

    public GameObject newLabDoor;
    public GameObject gardenDoorL;
    public GameObject gardenDoorR;

    public GameObject redKeycard;
    public GameObject greenKeycard;

    public GameObject redKeycardTrigger;
    public GameObject greenKeycardTrigger;

    public bool hTerminalTrigger = false;
    public bool hTerminalKeycardTrigger = false;
    public bool nLabDoorTrigger = false;
    public bool gDoorTrigger = false;
    public bool obtainedGreenKeycard = false;
    public bool obtainedRedKeycard = false;

    public static int keycardAmount = 0;

    public Text interactText;

    public GameObject thePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject == hackingTerminalTrigger)
        {
            interactText.text = "[ Press F to hack this terminal ]";
        }
        else if (gameObject == hackingTerminalKeycardTrigger)
        {
            // DONT NEED
        }
        else if (gameObject == newLabDoorTrigger)
        {
            if (obtainedRedKeycard == false)
            {
                interactText.text = "This door requires the red keycard to open";
            }
            else if (obtainedRedKeycard == true)
            {
                interactText.text = "[ Press F to open the door ]";
            }
        }
        else if (gameObject == gardenDoorTrigger)
        {
            if (obtainedGreenKeycard == false)
            {
                interactText.text = "this door requires the green keycard to open";
            }
            else if (obtainedGreenKeycard == true)
            {
                interactText.text = "[ Press F to open the door ]";
            }
        }
        else if (gameObject == redKeycardTrigger)
        {
            interactText.text = "[ Press F to pick up the red keycard ]";
            obtainedRedKeycard = true;
        }
        else if (gameObject == greenKeycardTrigger)
        {
            interactText.text = "[ Press F to pick up the green keycard ]";
            obtainedGreenKeycard = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        interactText.text = "";
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (gameObject == redKeycardTrigger)
            {
                Pickup();
            }
            else if (gameObject == greenKeycardTrigger)
            {
                Pickup();
            }
            else if (gameObject == hackingTerminalTrigger)
            {
                Hacking();
            }
            else if (gameObject == newLabDoorTrigger)
            {
                Open();
            }
            else if (gameObject == gardenDoorTrigger)
            {
                Open();
            }
        }
    }

    public void Pickup()
    {
        if (gameObject == redKeycardTrigger)
        {
            Destroy(redKeycard);
            interactText.text = "";
            Destroy(redKeycardTrigger);
            keycardAmount += 1;
        }
        else if (gameObject == greenKeycardTrigger)
        {
            Destroy(greenKeycard);
            interactText.text = "";
            Destroy(greenKeycardTrigger);
            keycardAmount += 1;
        }
    }

    public void Open()
    {
        
        if (gameObject == newLabDoorTrigger)
        {
            Destroy(newLabDoor);
            interactText.text = "";
            Destroy(newLabDoorTrigger);
        }
        else if (gameObject == gardenDoorTrigger)
        {
            Destroy(gardenDoorL);
            Destroy(gardenDoorR);
            interactText.text = "";
            Destroy(gardenDoorTrigger);
        }
    }

    public void Hacking()
    {
        if (gameObject == hackingTerminalTrigger)
        {

        }
    }

}
