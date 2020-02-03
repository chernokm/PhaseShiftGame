using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResourceDump : MonoBehaviour
{
	#region mushroom Objects
	[SerializeField]
	private GameObject Mushroom1;
	[SerializeField]
	private GameObject Mushroom2;
	[SerializeField]
	private GameObject Mushroom3;
	[SerializeField]
	private GameObject Mushroom4;
	#endregion

	[SerializeField]
	private Text interactionText;
	[SerializeField]
	private GameObject primaryObjective;

	[SerializeField]
	private GameObject depositText;

	private bool readyToEnd;

	private void Start()
	{
		Mushroom1.SetActive(false);
		Mushroom2.SetActive(false);
		Mushroom3.SetActive(false);
		Mushroom4.SetActive(false);
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
			interactionText.text = "";
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
		Mushroom1.SetActive(true);
		Mushroom2.SetActive(true);
		Mushroom3.SetActive(true);
		Mushroom4.SetActive(true);
		primaryObjective.SetActive(false);
		SceneManager.LoadScene(2);
	}
}
