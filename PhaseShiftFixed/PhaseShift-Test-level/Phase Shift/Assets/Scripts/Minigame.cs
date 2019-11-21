using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    public Sprite straightPipe;
    public Sprite tPipe;
    public Sprite cornerPipe;

    public Sprite pipeOn;
    public Sprite pipeOff;

    public Button b1;

    private bool isStraight;
    private bool isT;
    private bool isCorner;

    public void ChangeImage()
    {
        if(isStraight == false && isT == false && isCorner == false)
        {
            if(b1.image.sprite == pipeOn)
            {

                b1.image.sprite = pipeOff;
            }
            else
            {
                b1.image.sprite = pipeOn;
            }
        }
        else if (isStraight == true && isT == false && isCorner == false)
        {
            if (b1.image.sprite == pipeOn)
            {
                b1.image.sprite = straightPipe;
                isStraight = false;
            }
            else
            {
                b1.image.sprite = pipeOn;
            }
        }
        if (isStraight == false && isT == true && isCorner == false)
        {
            if (b1.image.sprite == pipeOn)
            {
                b1.image.sprite = tPipe;
                isT = false;
            }
            else
            {
                b1.image.sprite = pipeOn;
            }
        }
        if (isStraight == false && isT == false && isCorner == true)
        {
            if (b1.image.sprite == pipeOn)
            {
                b1.image.sprite = cornerPipe;
                isCorner = false;
            }
            else
            {
                b1.image.sprite = pipeOn;
            }
        }
    }

    public void SelectStraight()
    {
        isStraight = true;
    }

    public void SelectT()
    {
        isT = true;
    }

    public void SelectCorner()
    {
        isCorner = true;
    }

    public void DEBUGBUTTON13()
    {
        Debug.Log("WORKING");
    }
}
