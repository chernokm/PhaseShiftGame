using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Elevator : MonoBehaviour
{
	[SerializeField]
	private Text subtitlesText;

	[SerializeField]
	private GameObject elevatorDoor;

	[SerializeField]
	private GameObject elevatorTrigger;

	private int lineCount;

	private AudioSource audio;

	// Start is called before the first frame update
	void Start()
	{
		subtitlesText.text = "";
		audio = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		ElevatorScene();
	}

	private void OnTriggerExit(Collider other)
	{
		audio.Play();
		Destroy(elevatorTrigger);
		elevatorDoor.SetActive(true);
	}

	private void ElevatorScene()
	{
		if (lineCount == 0)
		{
			StartCoroutine(WaitForSound());
			subtitlesText.text = "Alright Theta, eyes up. You should have the most recent version of the Quantum Reality Environment Warper – God, that is a mouthful – Lab boys just call it the QREW.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 1)
		{
			StartCoroutine(WaitForSound());
			subtitlesText.text = "You’re going to see our signature Reality Disks scattered about, step on those to use the QREW. You’ll be zapped to the next one in sequence. You’ll know them when you see them.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 2)
		{
			StartCoroutine(WaitForSound());
			subtitlesText.text = "We’re sending you to Dimension 225, you’re going to be collecting 4 or so samples from there, they’re like mushrooms, but… not. Whatever. You’ll figure it out.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 3)
		{
			StartCoroutine(WaitForSound());
			subtitlesText.text = "When you’re done, throw them all into the equipment in the lab and we’ll be onto test 2. Nice and easy.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 4)
		{
			StartCoroutine(WaitForSound());
			subtitlesText.text = "And before you ask, again, no. We’re not talking about Epsilon, so stop asking about her. Good luck, Theta.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 5)
		{
			audio.Play();
			elevatorDoor.SetActive(false);
			StartCoroutine(WaitForSound());
			subtitlesText.text = "";
			StopCoroutine(WaitForSound());
		}
	}

	IEnumerator WaitForSound()
	{
		if(lineCount < 4)
		{
			yield return new WaitForSeconds(6);
			lineCount++;
			ElevatorScene();
		}
		else if(lineCount >= 4) //used for dramatic pauses
		{
			yield return new WaitForSeconds(8);
			lineCount++;
			ElevatorScene();
		}
	}
}
