using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Hacking : MonoBehaviour
{
	[SerializeField]
	private Canvas minigameCanvas;
	[SerializeField]
	private Canvas HUDCanvas;
	[SerializeField]
	private Text interactText;

	[SerializeField]
	private FirstPersonController fpsController;

	private void Awake()
	{
		minigameCanvas.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		interactText.text = "Press [F] to accept quest";
	}

	private void OnTriggerStay(Collider other)
	{
		if (Input.GetButtonDown("Interact"))
		{
			InitiatingTheHack();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		interactText.text = "";
	}

	//This script begins the minigame itself.
	private void InitiatingTheHack()
	{
		minigameCanvas.enabled = true;
		HUDCanvas.enabled = false;
		fpsController.enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;


	}

	//This method is attached to the "X" button in the top right of the game. 
	public void ExitHack()
	{
		fpsController.enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		HUDCanvas.enabled = true;
		minigameCanvas.enabled = false;
	}
}
