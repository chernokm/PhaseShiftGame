using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    public GameObject MushroomAmount;
    public GameObject KeycardAmount;
    //public static int mushroomAmount;


    void Update()
    {
        // Updating the HUD
        MushroomAmount.GetComponent<Text>().text = "" + ItemEvents.mushroomAmount;
        KeycardAmount.GetComponent<Text>().text = "" + ItemEvents.keycardAmount;
        
    }
    
}
