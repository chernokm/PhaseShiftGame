using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PhaseTest3 : MonoBehaviour
{
	#region serializedfields
	[SerializeField]
	private GameObject player;

	[SerializeField]
	private Text interactText;
	[SerializeField]
	private Image flashImage;

	[SerializeField]
	private AudioClip teleport;

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

	#endregion

	private FirstPersonController firstPersonController;
	private new AudioSource audio;

	
	private void Start()
	{
		audio = GetComponent<AudioSource>();
		flashImage.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		interactText.text = "[ press F to Dimensional Travel ]";
	}

	private void OnTriggerExit(Collider other)
	{
		interactText.text = "";
	}

	private void OnTriggerStay(Collider other) //Dimension hopping, folks, all aboard
	{
		if (Input.GetButtonDown("Interact"))
		{
			StartCoroutine(Countdown()); //used for the VFX and SFX
			StartCoroutine(Halt());
			if (toDimension1 == true)
			{
				if (backToDimension1 == true)
				{
					player.transform.position = D1TeleportReEntry.transform.position;
					Debug.Log("Travel backwards to dimension 1 from a dimension 2 portal");
				}
				else if (backToDimension1 == false)
				{
					player.transform.position = D1TeleportEntry.transform.position;
					Debug.Log("Travel to dimension 1, but the opposite side of the room.");
				}
			}
			else if (toDimension2 == true)
			{
				if (backToDimension2 == true)
				{
					player.transform.position = D2TeleportReEntry.transform.position;
					Debug.Log("Travel backwards to dimension 2 from a dimension 1 portal");
				}
				else if (backToDimension2 == false)
				{
					player.transform.position = D2TeleportEntry.transform.position;
					Debug.Log("Travel to dimension 2.");
				}
			}

		}
	}

	private IEnumerator Countdown() //used to create the dramatic flash when teleporting
	{
		flashImage.enabled = true;
		audio.PlayOneShot(teleport, 1);
		yield return new WaitForSeconds(0.1f);
		flashImage.enabled = false;
		interactText.text = "";
	}

	private IEnumerator Halt()
	{
		player.SetActive(false);
		yield return new WaitForSeconds(0.1f);
		player.SetActive(true);
	}
}
