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

	#region mushroomlogVariables
	[SerializeField]
	private Text headerTextMushroom;
	[SerializeField]
	private Text descBoxMushroom;
	[SerializeField]
	private Image TitleboxMushroom;
	[SerializeField]
	private Image descBoxBGMushroom;
	#endregion

	#region EpsilonlogVariables
	[SerializeField]
	private Text headerTextEpsilon;
	[SerializeField]
	private Text descBoxEpsilon;
	[SerializeField]
	private Image TitleboxEpsilon;
	[SerializeField]
	private Image descBoxBGEpsilon;
	[SerializeField]
	private Image audioplayer;
	#endregion

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
			AccessTerminal();
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

	public void MushroomReset() // used to reset the text
	{
		TitleboxMushroom.enabled = false;
		descBoxBGMushroom.enabled = false;
		headerTextMushroom.text = "";
		descBoxMushroom.text = "";
	}

	public void MushroomLog1()
	{
		TitleboxMushroom.enabled = true;
		descBoxBGMushroom.enabled = true;
		headerTextMushroom.text = "Mushroom log #1";
		descBoxMushroom.text = "We can now say with confidence that the gills of the mushrooms contain the highest quantity of zetamelaphin (ZMP). With a concentration [9] times stronger than the rest of the mushroom, this is where we will focus extraction efforts." + "\n" + "\n" + "Every attempt to grow the mushrooms here on Earth has failed. It seems for now we have to forage them from Dimension 225.";
	}

	public void MushroomLog2()
	{
		TitleboxMushroom.enabled = true;
		descBoxBGMushroom.enabled = true;
		headerTextMushroom.text = "Mushroom log #2";
		descBoxMushroom.text = "Important update: we’ve found a way to induce maturation of the basidia, reducing the time until optimal extraction by [3] weeks." + "\n" + "\n" + "Extraction of the ZMP from the gills has proven more complex than originally anticipated. While it is most potent when the mushrooms are producing spores, the spores have also induced severe reactions in [6] of our subjects." + "\n" + "\n" + "While we have extracted notable quantities of ZMP, we still don’t have enough to completely mitigate severe negative effects from phase shifting and occupying non-Earth dimensions. We do not recommend phase shifting until we’re able to gather at least [4] more mushrooms.";
	}

	public void EpsilonReset()
	{
		TitleboxEpsilon.enabled = false;
		descBoxBGEpsilon.enabled = false;
		audioplayer.enabled = false;
		headerTextEpsilon.text = "";
		descBoxEpsilon.text = "";
	}

	public void EpislonLog1()
	{
		TitleboxEpsilon.enabled = true;
		descBoxBGEpsilon.enabled = true;
		audioplayer.enabled = true;
		headerTextEpsilon.text = "Epsilon log #1";
		descBoxEpsilon.text = "This is subject Epsilon, going on maiden voyage of the Quantum Realm Environment Warper. Higher-ups said it would be a pretty simple setup, travel from dimension 1000 to dimension 350. This should be easy --";
	}
}
