using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dimension : MonoBehaviour
{
    public GameObject dimension1;
    public GameObject dimension2;
    public GameObject dimensionText;
    public bool dimension1Trigger = false;
    public bool dimension2Trigger = false;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        if (gameObject == dimension1)
        {
            dimension2Trigger = false;
            dimension1Trigger = true;
            DimensionShift();
            //dimensionText.GetComponent<Text>().text = "Dimension 1";
        }
        else if (gameObject == dimension2)
        {
            dimension1Trigger = false;
            dimension2Trigger = true;
            DimensionShift();
            //dimensionText.GetComponent<Text>().text = "Dimension 2";
        }
    }

    public void DimensionShift()
    {
        if (dimension1Trigger == true)
        {
            dimensionText.GetComponent<Text>().text = "Dimension 1";
        }
        else if (dimension2Trigger == true)
        {
            dimensionText.GetComponent<Text>().text = "Dimension 2";
        }
    }
}
