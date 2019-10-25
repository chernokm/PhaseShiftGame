using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{ 
    // Defines the source of the sound and what image is shown when teleporting
    public AudioSource teleportSound;
    public Image flash;

    void Update()
    {
        // If the player presses the "F" key
        if(Input.GetKeyDown(KeyCode.F))
        {
            // Starts the "Flash" Coroutine and plays the teleport sound
            StartCoroutine(Flash());
            teleportSound.Play();
        }
    }

    public IEnumerator Flash()
    {
        // Enables the image "flash", waits 0.5 then disables it so teleport seems more natural
        flash.enabled = true;
        yield return new WaitForSeconds(0.5f);
        flash.enabled = false;
    }
}
