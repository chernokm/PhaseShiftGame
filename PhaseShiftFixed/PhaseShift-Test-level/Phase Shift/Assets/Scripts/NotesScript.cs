using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class NotesScript : MonoBehaviour
{
	[SerializeField]
	private Image clipboardImage;
	[SerializeField]
	private Text clipboardText;

	[SerializeField]
	private Text interactionText;
	[SerializeField]
	private Text crosshairs;

	[SerializeField]
	private Canvas clipboardCanvas;

	[SerializeField]
	private bool isClipboard1;

	private FirstPersonController fpsController;

	private void Awake()
	{
		clipboardCanvas.enabled = false;
		clipboardText.text = "";
		fpsController = FindObjectOfType<FirstPersonController>();
	}

	private void OnTriggerEnter(Collider other)
	{
		interactionText.text = "Press [F] to read";
	}

	private void OnTriggerStay(Collider other)
	{
		if (Input.GetButtonDown("Interact"))
		{
			OpenMenu();
		}
	}

	private void OpenMenu()
	{
		if (isClipboard1 == true)
		{
			fpsController.enabled = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			crosshairs.text = "";
			interactionText.text = "";

			clipboardCanvas.enabled = true;
			clipboardImage.enabled = true;
			clipboardText.text = "Test 019" + "\n" + "\n" + "The flora - specifically the mushrooms - collected from Dimension 255 contain an overwhelming amount of Zetamelaphin, useful for counteracting the negative effects of cross-dimensional Phase Shifts, however..." + "\n" + "\n" + "It's insanely toxic. Avoid contact with bare skin if at all possible.";
		}
	}

	public void CloseMenu()
	{
		fpsController.enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		if(isClipboard1 == true)
		{
			clipboardCanvas.enabled = false;
			clipboardText.text = "";
			interactionText.text = "";
			crosshairs.text = "( : )";
		}
	}
}
