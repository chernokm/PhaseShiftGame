using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dimensions : MonoBehaviour
{
    public GameObject dimensionExterior;
    public GameObject dimensionLab;
    public GameObject dimensionInterior;

    public static bool dimensionTriggerExterior = false;
    public static bool dimensionTriggerLab = false;
    public static bool dimensionTriggerInterior = false;

    public GameObject thePlayer;
    //public GameObject dimensionText;

    void OnTriggerEnter(Collider other)
    {
        if (gameObject == dimensionExterior)
        {
            dimensionTriggerExterior = true;
            dimensionTriggerInterior = false;
            dimensionTriggerLab = false;
            //Shift();
        }
        else if (gameObject == dimensionLab)
        {
            dimensionTriggerExterior = false;
            dimensionTriggerInterior = false;
            dimensionTriggerLab = true;
            //Shift();
        }
        else if (gameObject == dimensionInterior)
        {
            dimensionTriggerExterior = false;
            dimensionTriggerInterior = true;
            dimensionTriggerLab = false;
            //Shift();
        }
    }

    //public void Shift()
    //{
    //    if (dimensionTriggerExterior == true)
    //    {
    //        dimensionText.GetComponent<Text>().text = "Dimension 225";
    //    }
    //    else if (dimensionTriggerInterior == true)
    //    {
    //        dimensionText.GetComponent<Text>().text = "Dimension 225";
    //    }
    //    else if (dimensionTriggerLab)
    //    {
    //        dimensionText.GetComponent<Text>().text = "Dimension 100";
    //    }
    //}


}
