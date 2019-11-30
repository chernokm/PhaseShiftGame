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

	#region gameobjects/triggers
	[SerializeField]
	private GameObject DoorLeft;
	[SerializeField]
	private GameObject DoorRight;
	[SerializeField]
	private GameObject finalTrigger;
	[SerializeField]
	private GameObject doorTrigger;
	#endregion

	#region audio
	private AudioSource audioSource;
	[SerializeField]
	private AudioClip doorOpen;
	[SerializeField]
	private AudioClip alpha1;
	[SerializeField]
	private AudioClip alpha2;
	[SerializeField]
	private AudioClip alpha3;
	[SerializeField]
	private AudioClip alpha4;
	#endregion

	[SerializeField]
	private GameObject TextPopup;

	private int lineCount;
	private float duration;

	public bool isSelected;

	private void Start()
	{
		Mushroom1.SetActive(false);
		Mushroom2.SetActive(false);
		Mushroom3.SetActive(false);
		Mushroom4.SetActive(false);
		TextPopup.SetActive(true);
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
		}
		//else if(ItemEvents.mushroomAmount < 4)
		//{
		//	TextPopup.SetActive(true);
		//}
	}

	private void OnTriggerStay(Collider other)
	{
		if(isSelected == false && ItemEvents.mushroomAmount ==4)
		{
			interactionText.text = "Press [ F ] to complete the chamber";
			if (Input.GetButtonDown("Interact"))
			{
				isSelected = true;
				Finish();
			}
		}
		else if (isSelected == true)
		{
			interactionText.text = "";
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
			duration = alpha1.length;
			StartCoroutine(WaitForApproval());
			audioSource.PlayOneShot(alpha1, 1);
			speakerButton.enabled = true;
			nameText.text = "<b>Alpha:</b>";
			subtitlesText.text = "Oh! You actually got something? Let me take a look here...";
			StopCoroutine(WaitForApproval());
		}
		if (lineCount == 1)
		{
			duration = alpha2.length;
			StartCoroutine(WaitForApproval());
			audioSource.PlayOneShot(alpha2, 1);
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
			duration = alpha3.length;
			StartCoroutine(WaitForApproval());
			audioSource.PlayOneShot(alpha3, 1);
			speakerButton.enabled = true;
			nameText.text = "<b>Alpha:</b>";
			subtitlesText.text = "Lab boys should've opened up the chamber for you now.";
			StopCoroutine(WaitForApproval());
		}
		if (lineCount == 3)
		{
			duration = alpha4.length;
			StartCoroutine(WaitForApproval());
			audioSource.PlayOneShot(alpha4, 1);
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
		yield return new WaitForSeconds(duration);
		lineCount++;
		Finish();
	}
}
