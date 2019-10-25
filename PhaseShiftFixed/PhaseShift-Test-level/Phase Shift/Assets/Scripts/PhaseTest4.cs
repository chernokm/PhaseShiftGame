using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PhaseTest4 : MonoBehaviour
{
	#region serializedfields
	[SerializeField]
	public Text interactText;
	[SerializeField]
	public Image flashImage;

	[SerializeField]
	public AudioClip teleport;

    /*
	[SerializeField]
	private bool toDimension1;
	[SerializeField]
	private bool toDimension2;
	[SerializeField]
	private bool backToDimension1;
	[SerializeField]
	private bool backToDimension2;


	[SerializeField]
	private GameObject D1TeleportEntry;
	[SerializeField]
	private GameObject D1TeleportReEntry;
	[SerializeField]
	private GameObject D2TeleportEntry;
	[SerializeField]
	private GameObject D2TeleportReEntry;
    */

    #endregion

    // Defines Triggers and targets for teleporting
    public GameObject teleportTrigger1;
    public GameObject teleportTrigger2;
    public GameObject teleportTrigger3;
    public GameObject teleportTrigger4;
    public GameObject teleportTarget1;
    public GameObject teleportTarget2;
    public GameObject teleportTarget3;
    public GameObject teleportTarget4;

    // Initializing the bools as false
    public bool teleportTriggerBool1 = false;
    public bool teleportTriggerBool2 = false;
    public bool teleportTriggerBool3 = false;
    public bool teleportTriggerBool4 = false;

    // Sets the player as a game object
    public GameObject thePlayer;
    
	private RigidbodyFirstPersonController firstPersonController;
	private new AudioSource audio;

	void Start()
	{
		audio = GetComponent<AudioSource>();
		flashImage.enabled = false;
		firstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
	}

	void OnTriggerEnter(Collider other)
	{
        // When hitting a trigger [ teleporter ] message pops up
        interactText.text = "[ press F to Dimensional Travel ]";
        
        // Checking which trigger is hit to determine what bool to set to true
        if (gameObject == teleportTrigger1)
        {
            teleportTriggerBool1 = true;
        }
        else if (gameObject == teleportTrigger2)
        {
            teleportTriggerBool2 = true;
        }
        else if (gameObject == teleportTrigger3)
        {
            teleportTriggerBool3 = true;
        }
        else if (gameObject == teleportTrigger4)
        {
            teleportTriggerBool4 = true;
        }

        

    }

	void OnTriggerExit(Collider other)
	{
		interactText.text = "";
	}

	void OnTriggerStay(Collider other) //Dimension hopping, folks, all aboard
	{
		if (Input.GetButtonDown("Interact"))
		{
			Shift();
		}
	}

	public void Shift()
	{
        // Checks to see which bool is set to true.
        if (teleportTriggerBool1 == true)
        {
            // If the first trigger bool is true, the player is sent to target 1 then the bool is set to its initial state
            thePlayer.transform.position = teleportTarget1.transform.position;
            teleportTriggerBool1 = false;
        }
        else if (teleportTriggerBool2 == true)
        {
            // Else if the second trigger bool is true, the player is sent to target 2 then the bool is set to its initial state
            thePlayer.transform.position = teleportTarget2.transform.position;
            teleportTriggerBool2 = false;
        }
        else if (teleportTriggerBool3 == true)
        {
            // Else if the third trigger bool is true, the player is sent to target 3 then the bool is set to its initial state
            thePlayer.transform.position = teleportTarget3.transform.position;
            teleportTriggerBool3 = false;
        }
        else if (teleportTriggerBool4 == true)
        {
            // Else if the fourth trigger bool is true, the player is sent to target 4 then the bool is set to its initial state
            thePlayer.transform.position = teleportTarget4.transform.position;
            teleportTriggerBool4 = false;
        }

        

    }

}
