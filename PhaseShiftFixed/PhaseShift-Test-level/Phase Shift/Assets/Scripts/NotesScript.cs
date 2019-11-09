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
	private bool isClipboard1;

	//private FirstPersonController fpsController;

	private void Awake()
	{
		clipboardImage.enabled = false;
		clipboardText.text = "";
		//fpsController = FindObjectOfType<FirstPersonController>();
	}

	private void OnTriggerEnter(Collider other)
	{
		interactionText.text = "Press [F] to read note";
	}

	private void OnTriggerExit(Collider other)
	{
		clipboardImage.enabled = false;
		clipboardText.text = "";
		interactionText.text = "";
		crosshairs.text = "( : )";
	}

	private void OnTriggerStay(Collider other)
	{
		if(isClipboard1 == true)
		{
			if (Input.GetButtonDown("Interact"))
			{
				crosshairs.text = "";
				interactionText.text = "";
				clipboardImage.enabled = true;
				clipboardText.text = "Scientific text goes here.";
			}
		}
	}
}
