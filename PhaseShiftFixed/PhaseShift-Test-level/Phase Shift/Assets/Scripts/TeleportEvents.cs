using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportEvents : MonoBehaviour
{
    public GameObject teleportTrigger1;
    public GameObject teleportTrigger2;
    public GameObject teleportTrigger3;
    public GameObject teleportTrigger4;
    public GameObject teleportTrigger5;
    public GameObject teleportTrigger6;
    public GameObject teleportTarget1;
    public GameObject teleportTarget2;
    public GameObject teleportTarget3;
    public GameObject teleportTarget4;
    public GameObject teleportTarget5;
    public GameObject teleportTarget6;

    //NEW TRIGGERS
    public GameObject hackingTerminalTrigger;
    public GameObject hackingTerminalKeycardTrigger;
    public GameObject newLabDoorTrigger;

    public GameObject thePlayer;

    public Text interactText;

    public Image flash;
    public AudioSource teleportSound;
	[SerializeField]
	private AudioClip woodDoor;

    public bool teleportTriggerBool1 = false;
    public bool teleportTriggerBool2 = false;
    public bool teleportTriggerBool3 = false;
    public bool teleportTriggerBool4 = false;
    public bool teleportTriggerBool5 = false;
    public bool teleportTriggerBool6 = false;

    private bool canTeleport = false;

	private void Start()
	{
		flash.enabled = false;
	}

	void OnTriggerEnter(Collider other)
    {
        canTeleport = true;
        if (gameObject == teleportTrigger1)
        {
            interactText.text = "[ press F to Dimensional Travel ]";
            teleportTriggerBool1 = true;
        }
        else if (gameObject == teleportTrigger2)
        {
            interactText.text = "[ press F to Dimensional Travel ]";
            teleportTriggerBool2 = true;
        }
        else if (gameObject == teleportTrigger3)
        {
            interactText.text = "[ press F to Enter the temple ]";
            teleportTriggerBool3 = true;
        }
        else if (gameObject == teleportTrigger4)
        {
            interactText.text = "[ press F to Exit the temple ]";
            teleportTriggerBool4 = true;
        }
        else if (gameObject == teleportTrigger5)
        {
            interactText.text = "[ press F to Dimensional Travel ]";
            teleportTriggerBool5 = true;
        }
        else if (gameObject == teleportTrigger6)
        {
            interactText.text = "[ press F to Dimensional Travel ]";
            teleportTriggerBool6 = true;
        }
        else if (gameObject == hackingTerminalTrigger)
        {
            interactText.text = "[ press F to hack the terminal ]";
        }
    }

    void OnTriggerExit(Collider other)
    {
        interactText.text = "";
        canTeleport = false;
    }

    void OnTriggerStay(Collider other)
    {
        canTeleport = true;        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && canTeleport)
        {
            EnableTeleportation();
        }
    }

    private void EnableTeleportation()
    {
        if (gameObject == teleportTrigger1)
        {
            teleportSound.Play();
            StartCoroutine(Flash());
            Teleport();
        }
        else if (gameObject == teleportTrigger2)
        {
            teleportSound.Play();
            StartCoroutine(Flash());
            Teleport();
        }
        else if (gameObject == teleportTrigger3)
        {
            teleportSound.PlayOneShot(woodDoor, 1);
            //StartCoroutine(Flash());
            Teleport();
        }
        else if (gameObject == teleportTrigger4)
        {
            teleportSound.PlayOneShot(woodDoor, 1);
            //StartCoroutine(Flash());
            Teleport();
        }
        else if (gameObject == teleportTrigger5)
        {
            teleportSound.Play();
            StartCoroutine(Flash());
            Teleport();
        }
        else if (gameObject == teleportTrigger6)
        {
            teleportSound.Play();
            StartCoroutine(Flash());
            Teleport();
        }
    }

    public void Teleport()
    {
        if (teleportTriggerBool1 == true)
        {
            thePlayer.transform.position = teleportTarget1.transform.position;
            teleportTriggerBool1 = false;
        }
        else if (teleportTriggerBool2 == true)
        {
            thePlayer.transform.position = teleportTarget2.transform.position;
            teleportTriggerBool2 = false;
        }
        else if (teleportTriggerBool3 == true)
        {
            thePlayer.transform.position = teleportTarget3.transform.position;
            teleportTriggerBool3 = false;
        }
        else if (teleportTriggerBool4 == true)
        {
            thePlayer.transform.position = teleportTarget4.transform.position;
            teleportTriggerBool4 = false;
        }
        else if (teleportTriggerBool5 == true)
        {
            thePlayer.transform.position = teleportTarget5.transform.position;
            teleportTriggerBool5 = false;
        }
        else if (teleportTriggerBool6 == true)
        {
            thePlayer.transform.position = teleportTarget6.transform.position;
            teleportTriggerBool6 = false;
        }
    }

    public IEnumerator Flash()
    {
        // Enables the image "flash", waits 0.5 then disables it so teleport seems more natural
        flash.enabled = true;
        yield return new WaitForSeconds(0.02f);
        flash.enabled = false;
    }
}
