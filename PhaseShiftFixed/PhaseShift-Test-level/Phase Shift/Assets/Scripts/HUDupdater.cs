using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDupdater : MonoBehaviour
{
	[SerializeField]
	private Text notificationText;
	[SerializeField]
	private Text tasklistText;

	Finale finalupdater = new Finale();

	private void Update()
	{
		UpdateTasklist();
		UpdateNotifications();
	}

	private void UpdateNotifications()
	{
		if(ItemEvents.obtainedInteriorLabKeycard == true)
		{
			StartCoroutine(WaitForTime());
			notificationText.text = "<b>RED Keycard</b> obtained";
			StopCoroutine(WaitForTime());
		}
		else if (ItemEvents.obtainedGardenKeycard == true)
		{
			StartCoroutine(WaitForTime());
			notificationText.text = "<b>GREEN Keycard</b> obtained";
			StopCoroutine(WaitForTime());
		}
	}

	private void UpdateTasklist()
	{
		if(ItemEvents.mushroomAmount < 4 && finalupdater.isSelected == false)
		{
			tasklistText.text = "- Collect (4) mushrooms for The Facility" + "\n" + "\n" + "- Bring samples back to 100 Lab tray" + "\n" + "\n" + "- Move to exit";
		}
		else if (ItemEvents.mushroomAmount == 4 && finalupdater.isSelected == false)
		{
			tasklistText.text = "- Bring samples back to 100 Lab tray" + "\n" + "\n" + "- Move to exit";
		}
		else if (ItemEvents.mushroomAmount == 4 && finalupdater.isSelected == true)
		{
			tasklistText.text = "- Move to exit";
		}
	}

	IEnumerator WaitForTime()
	{
		yield return new WaitForSeconds(3);
		notificationText.text = "";
	}
}
