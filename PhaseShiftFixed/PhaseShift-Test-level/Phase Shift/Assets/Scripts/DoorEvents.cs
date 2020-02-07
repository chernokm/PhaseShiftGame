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
	public GameObject hackedNotification;

	public AudioSource doorOpen;
	[SerializeField]
	private AudioClip itemPickup;

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
	public Image greenKeyCardIcon;
	public Image redKeyCardIcon;

    //public GameObject thePlayer;
    [SerializeField]
    private FirstPersonController fpsController;

	//HUDupdater headsupUpdater = new HUDupdater();

    private void Awake()
    {
        hackingCanvas.enabled = false;
		hackedNotification.SetActive(false);
		greenKeyCardIcon.enabled = false;
		redKeyCardIcon.enabled = false;
    }

	private void OnTriggerEnter(Collider other)
    {
        ShowUIText();
    }

    public void ShowUIText()
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        EmptyInteractText();
    }

    public void EmptyInteractText()
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
				keycardAmount--;
				redKeyCardIcon.enabled = false;
            }
            else if (gameObject == gardenDoorTrigger && obtainedGreenKeycard == true)
            {
                Open();
				keycardAmount--;
				greenKeyCardIcon.enabled = false;
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
			redKeyCardIcon.enabled = true;
			//headsupUpdater.UpdateNotifications();
		}
        else if (gameObject == greenKeycardTrigger)
        {
			doorOpen.PlayOneShot(itemPickup,1);
			obtainedGreenKeycard = true;
			Destroy(greenKeycard);
            interactText.text = "";
            Destroy(greenKeycardTrigger);
            keycardAmount += 1;
			greenKeyCardIcon.enabled = true;
			//headsupUpdater.UpdateNotifications();
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
			hackedNotification.SetActive(true);
			interactText.text = "[ Press F to pick up red keycard ]";
			Destroy(glass);

			//if(Minigame.isIncomplete == false)
			//{

			//}
			//else if (Minigame.isIncomplete == true)
			//{
			//	hackingCanvas.enabled = true;
			//	HUDcanvas.enabled = false;
			//	fpsController.enabled = false;
			//	Cursor.visible = true;
			//	Cursor.lockState = CursorLockMode.None;
			//	terminalHacked = false;
			//}
        }
    }

}
