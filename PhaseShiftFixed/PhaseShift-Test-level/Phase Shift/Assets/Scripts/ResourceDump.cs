using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResourceDump : MonoBehaviour
{
	[SerializeField]
	private Text interactionText;
	[SerializeField]
	private GameObject primaryObjective;

	[SerializeField]
	private GameObject depositText;

	private bool readyToEnd;

	private void Start()
	{
		depositText.SetActive(false);
	}

	private void Update()
	{
		CheckObjectivesCount();
	}

	private void CheckObjectivesCount()
	{
		if(ItemEvents.mushroomAmount == 4)
		{
			depositText.SetActive(true);
			readyToEnd = true;
		}
		else
		{
			depositText.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(readyToEnd == true)
		{
			interactionText.text = "Press [F] to finish mission";
		}
		else
		{
			interactionText.text = "This is where I'd deposit my samples.";
		}
	}

	private void OnTriggerExit(Collider other)
	{
		interactionText.text = "";
	}

	private void OnTriggerStay(Collider other)
	{
		if (Input.GetButtonDown("Interact"))
		{
			Finish();
		}
	}

	private void Finish()
	{
		primaryObjective.SetActive(false);
		SceneManager.LoadScene(2);
	}
}
