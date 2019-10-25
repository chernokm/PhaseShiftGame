using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseShift : MonoBehaviour
{
	[SerializeField]
	private GameObject player1Controller;
	[SerializeField]
	private GameObject player2Controller;
	[SerializeField]
	private bool toDimension1;
	[SerializeField]
	private bool toDimension2;

	private void OnTriggerEnter(Collider other)
	{
		if (toDimension1 == true)
		{
			SceneManager.LoadScene(0);
			player1Controller.SetActive(false);
			player2Controller.SetActive(true);
		}
		else if (toDimension2 == true)
		{
			SceneManager.LoadScene(1);
			player1Controller.SetActive(true);
			player2Controller.SetActive(false);
		}
	}
}
