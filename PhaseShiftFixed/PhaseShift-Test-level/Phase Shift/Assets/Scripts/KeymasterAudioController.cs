using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class KeymasterAudioController : MonoBehaviour
{
	#region AudioComponents
	public AudioSource audioSource;
	[SerializeField]
	private AudioClip guardianLineApproached;
	[SerializeField]
	private AudioClip guardianLineQuest1;
	[SerializeField]
	private AudioClip guardianLineQuest2;
	[SerializeField]
	private AudioClip guardianLineQuest3;
	[SerializeField]
	private AudioClip guardianLineIncomplete;
	[SerializeField]
	private AudioClip guardianLineEnding;

	private float duration;
	#endregion

	[SerializeField]
	private Text interactText;
	[SerializeField]
	private Text subtitlesText;

	public FirstPersonController fpsController;

	private int lineCount;
	private bool incompleteTask;
	private bool taskCompleted;

	private void OnTriggerEnter(Collider other)
	{
		interactText.text = "Press [F] to accept quest";
	}

	private void OnTriggerStay(Collider other)
	{
		if (Input.GetButtonDown("Interact"))
		{
			KeymasterQuest();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		interactText.text = "";
	}

	private void KeymasterQuest()
	{
		if (ItemEvents.mushroomAmount == 0 && ItemEvents.talkedToGuardian == false)
		{
			fpsController.enabled = false;
			CheckLinecount();
			ItemEvents.talkedToGuardian = true;
			Destroy(ItemEvents.interiorDoor);
			fpsController.enabled = true;
		}
		else if (ItemEvents.mushroomAmount >= 0 && ItemEvents.mushroomAmount < 5 && ItemEvents.talkedToGuardian == true)
		{
			incompleteTask = true;
			CheckLinecount();
		}
		else if (ItemEvents.mushroomAmount >= 5 && ItemEvents.talkedToGuardian == true)
		{
			taskCompleted = true;
			CheckLinecount();
			ItemEvents.obtainedGuardianKeycard = true;
			ItemEvents.keycardAmount += 1;
			ItemEvents.mushroomAmount = 0;
		}
	}

	private void CheckLinecount()
	{
		if (lineCount == 1)
		{
			duration = guardianLineApproached.length;
			StartCoroutine(WaitForSound());
			audioSource.PlayOneShot(guardianLineApproached, 1);
			subtitlesText.text = "Come traveler. I am the Keymaster. Complete my task to ensure safe passage.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 2)
		{
			duration = guardianLineQuest1.length;
			StartCoroutine(WaitForSound());
			audioSource.PlayOneShot(guardianLineQuest1, 1);
			subtitlesText.text = "Noble traveler. This is what I require for passage:";
			StopCoroutine(WaitForSound());
			
		}
		if (lineCount == 3)
		{
			duration = guardianLineQuest2.length;
			StartCoroutine(WaitForSound());
			audioSource.PlayOneShot(guardianLineQuest2, 1);
			subtitlesText.text = "5 mushrooms.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 4)
		{
			duration = guardianLineQuest3.length;
			StartCoroutine(WaitForSound());
			audioSource.PlayOneShot(guardianLineQuest3, 1);
			subtitlesText.text = "They are scattered between your dimension and my own. Bring them all to me.";
			StopCoroutine(WaitForSound());
		}
		else if (incompleteTask == true)
		{
			duration = guardianLineIncomplete.length;
			StartCoroutine(WaitForSound());
			audioSource.PlayOneShot(guardianLineIncomplete, 1);
			subtitlesText.text = "Noble Traveler, you have not acquired all the materials. Look again.";
			StopCoroutine(WaitForSound());
		}
		else if (taskCompleted == true)
		{
			duration = guardianLineEnding.length;
			StartCoroutine(WaitForSound());
			audioSource.PlayOneShot(guardianLineEnding, 1);
			subtitlesText.text = "Noble Traveler, I am thankful. Take this for safe passage. I wish thee well.";
			StopCoroutine(WaitForSound());
		}
	}

	IEnumerator WaitForSound()
	{
		yield return new WaitForSeconds(duration);
		if (lineCount < 4)
		{
			lineCount++;
		}
		CheckLinecount();
	}
}

