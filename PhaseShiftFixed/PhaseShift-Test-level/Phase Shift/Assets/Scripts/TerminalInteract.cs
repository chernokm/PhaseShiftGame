using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TerminalInteract : MonoBehaviour
{
	[SerializeField]
	private Canvas hudController;
	[SerializeField]
	private Canvas terminalCanvas;
	[SerializeField]
	private Text interactText;

	[SerializeField]
	private FirstPersonController fpsController;

	private void Awake()
	{
		terminalCanvas.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		interactText.text = "Press [F] to access Terminal";
	}

	private void OnTriggerStay(Collider other)
	{
		if (Input.GetButtonDown("Interact"))
		{
			
		}
	}

	private void OnTriggerExit(Collider other)
	{
		interactText.text = "";
	}

	private void AccessTerminal()
	{
		hudController.enabled = false;
		terminalCanvas.enabled = true;
		fpsController.enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void CloseTerminal()
	{
		fpsController.enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		hudController.enabled = true;
		terminalCanvas.enabled = false;
	}
}
