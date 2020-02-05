using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCANarea : MonoBehaviour
{
	#region triggerboxes
	[SerializeField]
	private GameObject courtyardTrigger;
	[SerializeField]
	private GameObject mazeTrigger;
	[SerializeField]
	private GameObject forestTrigger;
	[SerializeField]
	private GameObject labHUBTrigger;
	[SerializeField]
	private GameObject templeInteriorTrigger;
	#endregion

	#region booleanChecklist
	[SerializeField]
	private bool isInCourtyard;
	[SerializeField]
	private bool isInMaze;
	[SerializeField]
	private bool isInForest;
	[SerializeField]
	private bool isInLabHUB;
	[SerializeField]
	private bool isInTemple;
	#endregion

	[SerializeField]
	private Text scanDeviceDisplay;

	private void OnTriggerEnter(Collider other)
	{
		if (isInCourtyard == true && isInMaze == false && isInForest == false && isInLabHUB == false && isInTemple == false)
		{
			scanDeviceDisplay.text = "Courtyard";
		}
		else if (isInCourtyard == false && isInMaze == true && isInForest == false && isInLabHUB == false && isInTemple == false)
		{
			scanDeviceDisplay.text = "Hedge Maze";
		}
		else if (isInCourtyard == false && isInMaze == false && isInForest == true && isInLabHUB == false && isInTemple == false)
		{
			scanDeviceDisplay.text = "Forest";
		}
		else if (isInCourtyard == false && isInMaze == false && isInForest == false && isInLabHUB == true && isInTemple == false)
		{
			scanDeviceDisplay.text = "Lab HUB";
		}
		else if (isInCourtyard == false && isInMaze == false && isInForest == false && isInLabHUB == false && isInTemple == true)
		{
			scanDeviceDisplay.text = "Temple";
		}
	}
}
