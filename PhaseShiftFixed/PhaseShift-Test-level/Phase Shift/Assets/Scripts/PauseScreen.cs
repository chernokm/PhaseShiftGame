using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseScreen : MonoBehaviour
{
	[SerializeField]
	private Canvas hudCanvas;
	[SerializeField]
	private Canvas pauseCanvas;

	[SerializeField]
	private FirstPersonController fpsController;

	//public static bool pauseScreenEnabled;

	private void Awake()
	{
		pauseCanvas.enabled = false;
	}

	private void Update()
	{
		CheckIfPaused();
	}

	private void CheckIfPaused()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			hudCanvas.enabled = false;
			pauseCanvas.enabled = true;
			fpsController.enabled = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void ResumeButton()
	{
		fpsController.enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		pauseCanvas.enabled = false;
		hudCanvas.enabled = true;
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void QuitButton()
	{
		Application.Quit();
	}
}
