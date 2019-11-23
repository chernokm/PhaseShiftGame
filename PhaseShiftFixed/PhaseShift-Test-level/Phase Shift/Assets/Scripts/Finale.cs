using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finale : MonoBehaviour
{
	#region mushroom Objects
	[SerializeField]
	private GameObject Mushroom1;
	[SerializeField]
	private GameObject Mushroom2;
	[SerializeField]
	private GameObject Mushroom3;
	[SerializeField]
	private GameObject Mushroom4;
	#endregion

	#region UI elements
	[SerializeField]
	private Text interactionText;
	[SerializeField]
	private Text subtitlesText;
	[SerializeField]
	private Text nameText;
	[SerializeField]
	private Image speakerButton;
	#endregion

	[SerializeField]
	private GameObject DoorLeft;
	[SerializeField]
	private GameObject DoorRight;

	[SerializeField]
	private GameObject TextPopup;
	[SerializeField]
	private GameObject finalTrigger;
	[SerializeField]
	private GameObject doorTrigger;

	private AudioSource audioSource;
	[SerializeField]
	private AudioClip doorOpen;

	private int lineCount;

	private void Start()
	{
		Mushroom1.SetActive(false);
		Mushroom2.SetActive(false);
		Mushroom3.SetActive(false);
		Mushroom4.SetActive(false);
		TextPopup.SetActive(false);
		speakerButton.enabled = false;
		nameText.text = "";
		audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(ItemEvents.mushroomAmount == 4)
		{
			Mushroom1.SetActive(true);
			Mushroom2.SetActive(true);
			Mushroom3.SetActive(true);
			Mushroom4.SetActive(true);
			interactionText.text = "Press [ F ] to complete the chamber";
		}
		else if(ItemEvents.mushroomAmount < 4)
		{
			TextPopup.SetActive(true);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (Input.GetButtonDown("Interact"))
		{
			Finish();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		interactionText.text = "";
	}

	private void Finish()
	{
		ItemEvents.mushroomAmount = 0;
		interactionText.text = "";
		if (lineCount == 0)
		{
			StartCoroutine(WaitForApproval());
			speakerButton.enabled = true;
			nameText.text = "<b>Alpha:</b>";
			subtitlesText.text = "Oh! You actually got something? Let me take a look here...";
			StopCoroutine(WaitForApproval());
		}
		if (lineCount == 1)
		{
			StartCoroutine(WaitForApproval());
			speakerButton.enabled = true;
			nameText.text = "<b>Alpha:</b>";
			subtitlesText.text = "One. Two.. Three... Yep that's four.";
			StopCoroutine(WaitForApproval());
		}
		if (lineCount == 2)
		{
			Destroy(DoorLeft);
			Destroy(DoorRight);
			audioSource.PlayOneShot(doorOpen, 1);
			StartCoroutine(WaitForApproval());
			speakerButton.enabled = true;
			nameText.text = "<b>Alpha:</b>";
			subtitlesText.text = "Lab boys should've opened up the chamber for you now.";
			StopCoroutine(WaitForApproval());
		}
		if (lineCount == 3)
		{
			StartCoroutine(WaitForApproval());
			speakerButton.enabled = true;
			nameText.text = "<b>Alpha:</b>";
			subtitlesText.text = "How you get back is your own problem.";
			StopCoroutine(WaitForApproval());
		}
		if (lineCount == 4)
		{
			StartCoroutine(WaitForApproval());
			speakerButton.enabled = false;
			nameText.text = "";
			subtitlesText.text = "";
			StopCoroutine(WaitForApproval());
			finalTrigger.SetActive(false);
			Destroy(doorTrigger);
		}
	}

	private IEnumerator WaitForApproval()
	{
		yield return new WaitForSeconds(3);
		lineCount++;
		Finish();
	}
}
