using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalSceneCountdown : MonoBehaviour
{
	[SerializeField]
	private Text countdownText;

	private int timeLeft = 10;

	private void Start()
	{
		Countdown();
	}

	private void Countdown()
	{
		if(timeLeft == 10)
		{
			StartCoroutine(StartCountdown());
			countdownText.text = "The Facility will close this simulation in 10 seconds...";
			StopCoroutine(StartCountdown());
		}
		if (timeLeft == 9)
		{
			StartCoroutine(StartCountdown());
			countdownText.text = "The Facility will close this simulation in 9 seconds...";
			StopCoroutine(StartCountdown());
		}
		if (timeLeft == 8)
		{
			StartCoroutine(StartCountdown());
			countdownText.text = "The Facility will close this simulation in 8 seconds...";
			StopCoroutine(StartCountdown());
		}
		if (timeLeft == 7)
		{
			StartCoroutine(StartCountdown());
			countdownText.text = "The Facility will close this simulation in 7 seconds...";
			StopCoroutine(StartCountdown());
		}
		if (timeLeft == 6)
		{
			StartCoroutine(StartCountdown());
			countdownText.text = "The Facility will close this simulation in 6 seconds...";
			StopCoroutine(StartCountdown());
		}
		if (timeLeft == 5)
		{
			StartCoroutine(StartCountdown());
			countdownText.text = "The Facility will close this simulation in 5 seconds...";
			StopCoroutine(StartCountdown());
		}
		if (timeLeft == 4)
		{
			StartCoroutine(StartCountdown());
			countdownText.text = "The Facility will close this simulation in 4 seconds...";
			StopCoroutine(StartCountdown());
		}
		if (timeLeft == 3)
		{
			StartCoroutine(StartCountdown());
			countdownText.text = "The Facility will close this simulation in 3 seconds...";
			StopCoroutine(StartCountdown());
		}
		if (timeLeft == 2)
		{
			StartCoroutine(StartCountdown());
			countdownText.text = "The Facility will close this simulation in 2 seconds...";
			StopCoroutine(StartCountdown());
		}
		if (timeLeft == 1)
		{
			StartCoroutine(StartCountdown());
			countdownText.text = "The Facility will close this simulation in 1 seconds...";
			StopCoroutine(StartCountdown());
		}
		if(timeLeft == 0)
		{
			Application.Quit();
		}

	}

	private IEnumerator StartCountdown()
	{
		yield return new WaitForSeconds(1.2f);
		timeLeft--;
		Countdown();
	}
}
