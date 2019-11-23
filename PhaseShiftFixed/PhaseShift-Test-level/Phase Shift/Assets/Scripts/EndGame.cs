using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
	public Text interactText;

	private void OnTriggerEnter(Collider other)
	{
		interactText.text = "Press [F] to exit the test";
	}

	private void OnTriggerStay(Collider other)
	{
		if (Input.GetButtonDown("Interact"))
		{
			Exit();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		interactText.text = "";
	}

	private void Exit()
	{
		SceneManager.LoadScene(2);
	}
}
