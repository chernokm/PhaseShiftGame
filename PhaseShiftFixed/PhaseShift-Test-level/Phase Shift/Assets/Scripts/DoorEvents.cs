using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

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

    public GameObject glass;

	public AudioSource doorOpen;

    public bool hTerminalTrigger = false;
    public bool hTerminalKeycardTrigger = false;
    public bool nLabDoorTrigger = false;
    public bool gDoorTrigger = false;
    public static bool obtainedGreenKeycard = false;
    public static bool obtainedRedKeycard = false;
    public bool terminalHacked = false;

    public static int keycardAmount = 0;

    public Text interactText;
    public Canvas HUDcanvas;
    public Canvas hackingCanvas;

    //public GameObject thePlayer;
    [SerializeField]
    private FirstPersonController fpsController;

    private void Awake()
    {
        hackingCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject == hackingTerminalTrigger)
        {
            if (terminalHacked == true)
            {
                interactText.text = "[ Press F to pick up red keycard ]";
                obtainedRedKeycard = true;
            }
            else if (terminalHacked == false)
            {
                interactText.text = "[ Press F to hack this terminal ]";
            }
            
        }
        else if (gameObject == hackingTerminalKeycardTrigger)
        {
            // DONT NEED
        }
        else if (gameObject == newLabDoorTrigger)
        {
            if (obtainedRedKeycard == false)
            {
                interactText.text = "This door requires the Red keycard to open.";
            }
            else if (obtainedRedKeycard == true)
            {
                interactText.text = "[ Press F to open the door ]";
                keycardAmount -= 1;
            }
        }
        else if (gameObject == gardenDoorTrigger)
        {
            if (obtainedGreenKeycard == false)
            {
                interactText.text = "this door requires the Green keycard to open.";
            }
            else if (obtainedGreenKeycard == true)
            {
                interactText.text = "[ Press F to open the door ]";
                keycardAmount -= 1;
            }
        }
        else if (gameObject == redKeycardTrigger)
        {
            //interactText.text = "[ Press F to pick up the red keycard ]";
            //obtainedRedKeycard = true;
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
                //keycardAmount += 1;
            }
            else if (gameObject == hackingTerminalTrigger)
            {
                if (terminalHacked == true)
                {
                    Pickup();
                    obtainedRedKeycard = true;
                    //keycardAmount += 1;
                }
                else if (terminalHacked == false)
                {
                    Hacking();
                }
                
            }
            else if (gameObject == newLabDoorTrigger && obtainedRedKeycard == true)
            {
                Open();
            }
            else if (gameObject == gardenDoorTrigger && obtainedGreenKeycard == true)
            {
                Open();
            }
        }
    }

    public void Pickup()
    {
        if (gameObject == hackingTerminalTrigger)
        {
            Destroy(redKeycard);
            interactText.text = "";
            Destroy(hackingTerminalTrigger);
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
			doorOpen.Play();
            interactText.text = "";
            Destroy(newLabDoorTrigger);
        }
        else if (gameObject == gardenDoorTrigger)
        {
            Destroy(gardenDoorL);
            Destroy(gardenDoorR);
            interactText.text = "";
			doorOpen.Play();
            Destroy(gardenDoorTrigger);
        }
    }

    public void Hacking()
    {
        if (gameObject == hackingTerminalTrigger)
        {
            hackingCanvas.enabled = true;
            HUDcanvas.enabled = false;
            fpsController.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            terminalHacked = true;
            interactText.text = "[ Press F to pick up red keycard ]";
            Destroy(glass);
        }
    }

}
