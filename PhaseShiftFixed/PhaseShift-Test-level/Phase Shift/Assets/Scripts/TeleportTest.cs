using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTest : MonoBehaviour
{
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject Dimension2TPin;

	private void OnTriggerEnter(Collider other)
	{
		player.transform.position = Dimension2TPin.transform.position;
		StartCoroutine(Halt());
	}

	private IEnumerator Halt()
	{
		player.SetActive(false);
		yield return new WaitForSeconds(0.1f);
		player.SetActive(true);
	}
}
