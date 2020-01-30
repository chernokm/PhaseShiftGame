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
	private Text nameText;
	[SerializeField]
	private Image speakerButton;
	[SerializeField]
	private Text notificationText;

	[SerializeField]
	private GameObject elevatorDoor;

	[SerializeField]
	private GameObject elevatorTrigger;

	#region voice lines
	[SerializeField]
	private AudioClip Alpha1;
	[SerializeField]
	private AudioClip Alpha2;
	[SerializeField]
	private AudioClip Alpha3;
	[SerializeField]
	private AudioClip Alpha4;
	[SerializeField]
	private AudioClip Alpha5;
	#endregion

	private int lineCount;
	private bool dialougeSkipped;

	private AudioSource audio;
	private float duration;

	[SerializeField]
	private AudioClip doorOpen;
	[SerializeField]
	private AudioClip elevatorRide;
	[SerializeField]
	private AudioClip ding;

	// Start is called before the first frame update
	void Start()
	{
		speakerButton.enabled = true;
		nameText.text = "";
		subtitlesText.text = "";
		audio = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		ElevatorScene();
		notificationText.text = "Press [ESC] to skip cutscene";
	}

	private void OnTriggerStay(Collider other)
	{
		if (dialougeSkipped == false)
		{
			if (Input.GetButtonDown("Cancel"))
			{
				DialogueSkip();
			}
		}
		else if(dialougeSkipped == true)
		{

		}
	}

	private void OnTriggerExit(Collider other)
	{
		//audio.Play();
		Destroy(elevatorTrigger);
		elevatorDoor.SetActive(true);
	}

	private void ElevatorScene()
	{
		//audio.PlayOneShot(elevatorRide, 1);
		if (lineCount == 0)
		{
			duration = Alpha1.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(Alpha1, 1);
			nameText.text = "<b>Alpha:</b>";
			subtitlesText.text = "Alright Theta, eyes up. You should have the most recent version of the Quantum Reality Environment Warper – God, that is a mouthful – Lab boys just call it the QREW.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 1)
		{
			duration = Alpha2.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(Alpha2, 1);
			nameText.text = "<b>Alpha:</b>";
			subtitlesText.text = "You’re going to see our signature Reality Disks scattered about, step on one of those to use the QREW. You’ll be zapped to the next one in sequence. You’ll know them when you see them.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 2)
		{
			duration = Alpha3.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(Alpha3, 1);
			nameText.text = "<b>Alpha:</b>";
			subtitlesText.text = "We’re sending you to Dimension 225, you’re going to be collecting 4 or so samples from there, they’re like mushrooms, but… not. Whatever. You’ll figure it out.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 3)
		{
			duration = Alpha4.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(Alpha4, 1);
			nameText.text = "<b>Alpha:</b>";
			subtitlesText.text = "When you’re done, throw them all onto the tray in the lab and we’ll be onto test 2. Nice and easy.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 4)
		{
			duration = Alpha5.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(Alpha5, 1);
			nameText.text = "<b>Alpha:</b>";
			subtitlesText.text = "And before you ask, again, no. We’re not talking about Epsilon, so stop asking about her. Good luck out there, Theta.";
			StopCoroutine(WaitForSound());
			//audio.Stop();
			audio.PlayOneShot(ding, 1);
		}
		if (lineCount == 5)
		{
			audio.PlayOneShot(doorOpen, 1);
			elevatorDoor.SetActive(false);
			speakerButton.enabled = false;
			nameText.text = "";
			subtitlesText.text = "";
			notificationText.text = "";
		}
	}

	IEnumerator WaitForSound()
	{ 
		yield return new WaitForSeconds(duration);
		lineCount++;
		ElevatorScene();
	}

	private void DialogueSkip()
	{
		dialougeSkipped = true;
		lineCount = 5;
		audio.Stop();
		audio.PlayOneShot(doorOpen, 1);
		elevatorDoor.SetActive(false);
		speakerButton.enabled = false;
		nameText.text = "";
		subtitlesText.text = "";
		notificationText.text = "";
	}
}
