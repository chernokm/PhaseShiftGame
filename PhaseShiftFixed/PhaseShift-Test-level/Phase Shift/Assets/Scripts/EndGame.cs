using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene(2);
	}

	public void Restart()
	{
		SceneManager.LoadScene(0);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
