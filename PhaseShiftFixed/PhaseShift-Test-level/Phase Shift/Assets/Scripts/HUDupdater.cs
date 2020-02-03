using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDupdater : MonoBehaviour
{
	[SerializeField]
	private Text primaryObjectiveText;
	[SerializeField]
	private Text primaryObjectiveNumber;

	private void Start()
	{
		primaryObjectiveText.text = "Zetamelaphin Mushrooms";
		primaryObjectiveNumber.text = "0/4";
	}

	private void Update()
	{
		UpdateObjectives();
	}

	private void UpdateObjectives()
	{
		if(ItemEvents.mushroomAmount == 0)
		{
			primaryObjectiveNumber.text = "0/4";
		}
		else if (ItemEvents.mushroomAmount == 1)
		{
			primaryObjectiveNumber.text = "1/4";
		}
		else if (ItemEvents.mushroomAmount == 2)
		{
			primaryObjectiveNumber.text = "2/4";
		}
		else if (ItemEvents.mushroomAmount == 3)
		{
			primaryObjectiveNumber.text = "3/4";
		}
		else if (ItemEvents.mushroomAmount == 4)
		{
			primaryObjectiveText.text = "Objective Complete - Return to base";
			primaryObjectiveNumber.text = "";
		}
	}

}
