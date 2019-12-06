using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEvents : MonoBehaviour
{
	//Regions subdivided for sake of clarity
	#region Triggerboxes
	public GameObject guardianInteractTrigger;
    public GameObject miniGuardianTrigger;
    public GameObject labDoorTrigger;
    public GameObject interiorLabDoorTrigger;
    public GameObject gardenDoorTrigger;
    public GameObject endingTrigger;
	#endregion

	#region gameobjects
	public GameObject interiorLabDoor;
    public GameObject mainLabDoorL;
    public GameObject mainLabDoorR;
    public GameObject gardenDoor;

    public GameObject mazeDoor;
    #endregion

	#region Item Triggers
	public GameObject mushroomTrigger1;
    public GameObject mushroomTrigger2;
    public GameObject mushroomTrigger3;
    public GameObject mushroomTrigger4;
    public GameObject mushroomTrigger5;

    //public GameObject keycardTrigger1;
    //public GameObject keycardTrigger2;
	#endregion

	#region Items
	public GameObject mushroom1;
    public GameObject mushroom2;
    public GameObject mushroom3;
    public GameObject mushroom4;
    public GameObject mushroom5;

	//public GameObject keycard1;
	//public GameObject keycard2;
	#endregion

	public AudioSource audio;

	public GameObject thePlayer;
    public Text interactText;
	
	//public GameObject MushroomAmount;
	public static int mushroomAmount = 0;
    public static int keycardAmount = 0;

    //public GameObject guardianKeycard;
    public static bool obtainedGuardianKeycard = false;
    public static bool talkedToGuardian = false;
    public static bool obtainedGardenKeycard = false;
    public static bool obtainedInteriorLabKeycard = false;


	void OnTriggerEnter(Collider other)
    {
        //if (gameObject == guardianInteractTrigger)
        //{
        //    if (mushroomAmount == 0 && talkedToGuardian == false)
        //    {
        //        interactText.text = "Collect [ 5 ] mushrooms for me and I will give you the keycard your Facility requires.";
        //        talkedToGuardian = true;
        //        Destroy(interiorDoor);
        //        //obtainedGardenKeycard = true;
        //        //obtainedInteriorLabKeycard = true;
        //    }
        //    else if (mushroomAmount >= 0 && mushroomAmount < 5 && talkedToGuardian == true)
        //    {
        //        interactText.text = "You do not have enough mushrooms yet. Come back when you have [ 5 ].";
        //    }
        //    else if (mushroomAmount >= 5 && talkedToGuardian == true)
        //    {
        //        interactText.text = "Thanks for the mushrooms! Here's that keycard I promised.";
        //        obtainedGuardianKeycard = true;
        //        keycardAmount += 1;
        //        mushroomAmount = 0;
        //    }
        //}
        if (gameObject == miniGuardianTrigger)
        {
            if (talkedToGuardian == false)
            {
                interactText.text = "This statue stares at you with absent eyes.";
            }
            //else if (talkedToGuardian == true)
            //{
            //    interactText.text = "Oh, you talked to the Guardian now? Great! Welcome to my maze!";
            //    Destroy(mazeDoor);
                
            //}
        }
        else if (gameObject == labDoorTrigger)
        {
            if (obtainedGuardianKeycard == false)
            {
                interactText.text = "This door's the way out. I need to finish my Tasks first.";
            }
            else if (obtainedGuardianKeycard == true)
            {
                interactText.text = "[ Press F to open the door ]";
            }
            
        }
        else if (gameObject == interiorLabDoorTrigger)
        {
            if (obtainedInteriorLabKeycard == false)
            {
                interactText.text = "You need the RED Keycard to open this door.";
            }
            else if (obtainedInteriorLabKeycard == true)
            {
                interactText.text = "[ Press F to use the keycard ]";
				//keycardAmount -= 1;
            }
        }
        else if (gameObject == gardenDoorTrigger)
        {
            if (obtainedGardenKeycard == false)
            {
                interactText.text = "You need the GREEN Keycard to open this door.";
            }
            else if (obtainedGardenKeycard == true)
            {
                interactText.text = "[ Press F to use the keycard ]";
				//keycardAmount -= 1;
			}
        }
        else if (gameObject == mushroomTrigger1)
        {
            interactText.text = "[ Press F to pick up the mushroom ]";
        }
        else if (gameObject == mushroomTrigger2)
        {
            interactText.text = "[ Press F to pick up the mushroom ]";
        }
        else if (gameObject == mushroomTrigger3)
        {
            interactText.text = "[ Press F to pick up the mushroom ]";
        }
        else if (gameObject == mushroomTrigger4)
        {
            interactText.text = "[ Press F to pick up the mushroom ]";
        }
        else if (gameObject == mushroomTrigger5)
        {
            interactText.text = "[ Press F to pick up the mushroom ]";
        }
        //else if (gameObject == keycardTrigger1)
        //{
        //    interactText.text = "[ Press F to pick up the keycard ]";
        //    obtainedInteriorLabKeycard = true;
        //}
        //else if (gameObject == keycardTrigger2)
        //{
        //    interactText.text = "[ Press F to pick up the keycard ]";
        //    obtainedGardenKeycard = true;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        interactText.text = "";
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (gameObject == mushroomTrigger1)
            {
                Pickup();
            }
            else if (gameObject == mushroomTrigger2)
            {
                Pickup();
            }
            else if (gameObject == mushroomTrigger3)
            {
                Pickup();
            }
            else if (gameObject == mushroomTrigger4)
            {
                Pickup();
            }
            else if (gameObject == mushroomTrigger5)
            {
                Pickup();
            }
            //else if (gameObject == keycardTrigger1)
            //{
            //    //obtainedInteriorLabKeycard = true;
            //    Pickup();
                
            //}
            //else if (gameObject == keycardTrigger2)
            //{
            //    //obtainedGardenKeycard = true;
            //    Pickup();
            //}
            else if (gameObject == interiorLabDoorTrigger && obtainedInteriorLabKeycard == true)
            {
                Open();
                
            }
            else if (gameObject == gardenDoorTrigger && obtainedGardenKeycard == true)
            {
                Open();
            }
            else if (gameObject == labDoorTrigger)
            {
                Open();
            }

        }
    }

    public void Pickup()
    {
        if (gameObject == mushroomTrigger1)
        {
			audio.Play();
            Destroy(mushroom1);
            interactText.text = "";
            Destroy(mushroomTrigger1);
            mushroomAmount += 1;
        }
        else if (gameObject == mushroomTrigger2)
        {
			audio.Play();
			Destroy(mushroom2);
            interactText.text = "";
            Destroy(mushroomTrigger2);
            mushroomAmount += 1;
        }
        else if (gameObject == mushroomTrigger3)
        {
			audio.Play();
			Destroy(mushroom3);
            interactText.text = "";
            Destroy(mushroomTrigger3);
            mushroomAmount += 1;
        }
        else if (gameObject == mushroomTrigger4)
        {
			audio.Play();
			Destroy(mushroom4);
            interactText.text = "";
            Destroy(mushroomTrigger4);
            mushroomAmount += 1;
        }
        else if (gameObject == mushroomTrigger5)
        {
			audio.Play();
			Destroy(mushroom5);
            interactText.text = "";
            Destroy(mushroomTrigger5);
            mushroomAmount += 1;
        }
        //else if (gameObject == keycardTrigger1)
        //{
        //    //obtainedInteriorLabKeycard = true;
        //    Destroy(keycard1);
        //    interactText.text = "";
        //    Destroy(keycardTrigger1);
        //    keycardAmount += 1;
        //    //obtainedInteriorLabKecard = true;
            
        //}
        //else if (gameObject == keycardTrigger2)
        //{
        //    //obtainedGardenKeycard = true;
        //    Destroy(keycard2);
        //    interactText.text = "";
        //    Destroy(keycardTrigger2);
        //    keycardAmount += 1;
        //    //obtainedGardenKeycard = true;
            
        //}
    }

    public void Open()
    {
        if (gameObject == interiorLabDoorTrigger)
        {
            Destroy(interiorLabDoor);
            interactText.text = "";
            Destroy(interiorLabDoorTrigger);
        }
        else if (gameObject == gardenDoorTrigger)
        {
            Destroy(gardenDoor);
            interactText.text = "";
            Destroy(gardenDoorTrigger);
        }
        else if (gameObject == labDoorTrigger)
        {
            Destroy(mainLabDoorL);
            Destroy(mainLabDoorR);
            interactText.text = "";
        }
    }
    

}
