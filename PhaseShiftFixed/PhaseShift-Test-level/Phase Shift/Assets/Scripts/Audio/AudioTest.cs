using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/sx_test", GetComponent<Transform>().position);
        //debug
        Debug.Log("You should hear squish sound");
    }
}
