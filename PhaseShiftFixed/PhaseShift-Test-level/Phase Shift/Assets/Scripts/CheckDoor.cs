using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDoor : MonoBehaviour
{
	[SerializeField]
	private Text indicatorText;

	private void OnTriggerStay(Collider other)
	{
		if(Inventory.KeycardAmount >= 1)
		{
			indicatorText.text = "Press [F] to open the door.";
		}
		else if(Inventory.KeycardAmount == 0)
		{
			indicatorText.text = "Collect a Keycard to open this door.";
		}
	}

	private void OnTriggerExit(Collider other)
	{
		indicatorText.text = "";
	}
}
