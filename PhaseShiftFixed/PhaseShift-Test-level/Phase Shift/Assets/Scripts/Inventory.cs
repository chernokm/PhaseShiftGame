using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    public GameObject keycardAmount;
    public static int KeycardAmount;


    void Update()
    {
        // Updating the HUD
        keycardAmount.GetComponent<Text>().text = "" + KeycardAmount;
        
    }
    
}
