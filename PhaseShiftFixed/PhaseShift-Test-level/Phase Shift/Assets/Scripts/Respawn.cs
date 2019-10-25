using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
