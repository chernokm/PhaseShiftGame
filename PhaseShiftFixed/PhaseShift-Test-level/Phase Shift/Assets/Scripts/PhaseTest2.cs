using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseTest2 : MonoBehaviour
{
	#region serialized fields
	[Tooltip("The controller on the closest ledge to spawn.")]
	[SerializeField]
	private GameObject player1Controller;

	[Tooltip("The controller opposite 1, near the green door.")]
	[SerializeField]
	private GameObject player2Controller;

	[Tooltip("The controller in dimension B, closest to the Blue wall.")]
	[SerializeField]
	private GameObject player1BController;

	[Tooltip("The controller in dimension B, closest to the Orange wall. Used to re-navigate Dimension B in reverse.")]
	[SerializeField]
	private GameObject player2BController;

	[SerializeField]
	private bool toDimension1;
	[SerializeField]
	private bool toDimension2;
	[SerializeField]
	private bool backToDimension1;
	[SerializeField]
	private bool backToDimension2;

	[SerializeField]
	private Text interactText;
	[SerializeField]
	private Image flashImage;

	[SerializeField]
	private AudioClip teleport;
	#endregion

	private new AudioSource audio;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
		flashImage.enabled = false;
	}

	private void Update()
	{
		CheckPlayerEyes();
	}

	private void OnTriggerEnter(Collider other)
	{
		interactText.text = "[ press F to Dimensional Travel ]";
	}

	private void OnTriggerExit(Collider other)
	{
		interactText.text = "";
	}

	private void OnTriggerStay(Collider other)
	{
		if (Input.GetButtonDown("Interact"))
		{
			StartCoroutine(Countdown());
			if (toDimension1 == true)
			{
				if (backToDimension1 == true)
				{
					player1BController.SetActive(false);
					player2BController.SetActive(false);
					player1Controller.SetActive(true);
				}
				else if (backToDimension1 == false)
				{
					player1BController.SetActive(false);
					player2Controller.SetActive(true);
				}
			}
			else if (toDimension2 == true)
			{
				if (backToDimension2 == true)
				{
					player1Controller.SetActive(false);
					player2Controller.SetActive(false);
					player2BController.SetActive(true);
				}
				else if (backToDimension2 == false)
				{
					player1Controller.SetActive(false);
					player1BController.SetActive(true);
				}
			}
		}
	}

	private IEnumerator Countdown() //used to create the dramatic flash when teleporting
	{
		flashImage.enabled = true;
		audio.PlayOneShot(teleport, 1);
		yield return new WaitForSeconds(0.1f);
		interactText.text = "";
		flashImage.enabled = false;
	}

	private void CheckPlayerEyes() //simply used for debugging purposes
	{
		if(player1Controller == true)
		{
			Debug.Log("Player 1 eyes");
		}
		else if (player1BController == true)
		{
			Debug.Log("Player 1B eyes");
		}
		else if (player2Controller == true)
		{
			Debug.Log("Player 2 eyes");
		}
		else if (player2BController == true)
		{
			Debug.Log("Player 2B eyes");
		}
	}
}
