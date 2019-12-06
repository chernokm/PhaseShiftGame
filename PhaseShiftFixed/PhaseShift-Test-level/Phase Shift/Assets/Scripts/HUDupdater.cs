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

	private bool hasRedCard;
	private bool hasGreenCard;
	Finale finalupdater = new Finale();

	private void Start()
	{
		notificationText.text = "";
		tasklistText.text = "- Collect (4) mushrooms for The Facility" + "\n" + "\n" + "- Bring samples back to 100 Lab tray" + "\n" + "\n" + "- Move to exit";
	}

	private void Update()
	{
		//UpdateTasklist();
		UpdateNotifications();
	}

	public void UpdateNotifications()
	{
		if(DoorEvents.obtainedRedKeycard == true && hasRedCard == false)
		{
			StartCoroutine(WaitForTime());
			notificationText.text = "<b>RED Keycard</b> obtained";
			hasRedCard = true;
			StopCoroutine(WaitForTime());
		}
		else if (DoorEvents.obtainedGreenKeycard == true && hasGreenCard == false)
		{
			StartCoroutine(WaitForTime());
			notificationText.text = "<b>GREEN Keycard</b> obtained";
			hasGreenCard = true;
			StopCoroutine(WaitForTime());
		}
	}

	//private void UpdateTasklist()
	//{
	//	if(ItemEvents.mushroomAmount < 4 && finalupdater.isSelected == false)
	//	{
	//		tasklistText.text = "- Collect (4) mushrooms for The Facility" + "\n" + "\n" + "- Bring samples back to 100 Lab tray" + "\n" + "\n" + "- Move to exit";
	//	}
	//	else if (ItemEvents.mushroomAmount == 4 && finalupdater.isSelected == false)
	//	{
	//		tasklistText.text = "- Bring samples back to 100 Lab tray" + "\n" + "\n" + "- Move to exit";
	//	}
	//	else if (finalupdater.isSelected == true)
	//	{
	//		tasklistText.text = "";
	//	}
	//}

	IEnumerator WaitForTime()
	{
		yield return new WaitForSeconds(3);
		notificationText.text = "";
	}
}
