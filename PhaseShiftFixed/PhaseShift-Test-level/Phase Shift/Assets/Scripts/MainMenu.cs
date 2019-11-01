using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField]
	private Image thetaPrime;
	[SerializeField]
	private Image thetaAlt;
	[SerializeField]
	private Image flash;

	private bool clickStart;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(PhaseChange());
		thetaAlt.enabled = false;
		flash.enabled = false;
	}

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	//Used to change the background image between two images without pushing any buttons
	IEnumerator PhaseChange()
	{
		while (clickStart == false)
		{
			StartCoroutine(Flash());
			yield return new WaitForSeconds(5);
			Debug.Log("This is the alt form.");
			flash.enabled = false;
			thetaPrime.enabled = false;
			thetaAlt.enabled = true;

			StartCoroutine(Flash());
			yield return new WaitForSeconds(5);
			Debug.Log("This is the original form.");
			flash.enabled = false;
			thetaPrime.enabled = true;
			thetaAlt.enabled = false;
		}
	}

	//A simple flash to make PhaseChange go smoother
	IEnumerator Flash()
	{
		flash.enabled = true;
		yield return new WaitForSeconds(0.02f);
		flash.enabled = false;
	}
}
