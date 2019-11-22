﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Minigame : MonoBehaviour
{
	#region pipe sprites
	public Sprite straightPipe;
	public Sprite straightUnpowered;
    public Sprite tPipe;
    public Sprite cornerPipe;

    public Sprite pipeOn;
    public Sprite pipeOff;
	#endregion

	#region buttons
	public Button b1;
	public Button b2;
	public Button buttonRight1;
	public Button buttonRight2;
	public Button buttonUp1;
	public Button buttonUp2;
	#endregion

	#region booleans
	private bool isStraight;
    private bool isT;
    private bool isCorner;

	private bool powerGoingRight;
	private bool powerGoingUp;
	#endregion

	public Image hackSuccessful;
    public Canvas hackingCanvas;

    public GameObject redCardTrigger;

    public Canvas hudCanvas;

    [SerializeField]
    private FirstPersonController fpsController;

    public AudioSource audioSource;

	private void Awake()
	{
		hackSuccessful.enabled = false;
	}

	public void ChangeImage() // for the bottom center panel exclusively.
    {
        if(isStraight == false && isT == false && isCorner == false) // no piece
        {
			if (b1.image.sprite == pipeOn)
            {
                b1.image.sprite = pipeOff;
				buttonRight1.image.sprite = straightUnpowered;
				buttonRight2.image.sprite = straightUnpowered;
				powerGoingRight = false;
			}
            else
            {
                b1.image.sprite = pipeOn;
				buttonRight1.image.sprite = straightPipe;
				buttonRight2.image.sprite = straightPipe;
				buttonUp1.image.sprite = straightUnpowered;
				powerGoingRight = true;
			}
        }
        else if (isStraight == true && isT == false && isCorner == false) // straight piece
        {
            if (b1.image.sprite == pipeOn || b1.image.sprite == pipeOff)
            {
                b1.image.sprite = straightPipe;
                isStraight = false;
				buttonRight1.image.sprite = straightPipe;
				buttonRight2.image.sprite = straightPipe;
				buttonUp1.image.sprite = straightUnpowered;
				powerGoingRight = true;
				powerGoingUp = false;
			}
        }
        if (isStraight == false && isT == true && isCorner == false) // T-piece
        {
            if (b1.image.sprite == pipeOn || b1.image.sprite == pipeOff)
            {
                b1.image.sprite = tPipe;
                isT = false;
				buttonRight1.image.sprite = straightPipe;
				buttonRight2.image.sprite = straightPipe;
				buttonUp1.image.sprite = straightPipe;
				powerGoingRight = true;
				powerGoingUp = true;
			}
        }
        if (isStraight == false && isT == false && isCorner == true) // Elbow piece
        {
            if (b1.image.sprite == pipeOn || b1.image.sprite == pipeOff)
            {
                b1.image.sprite = cornerPipe;
                isCorner = false;
				buttonRight1.image.sprite = straightUnpowered;
				buttonRight2.image.sprite = straightUnpowered;
				buttonUp1.image.sprite = straightPipe;
				powerGoingRight = false;
				powerGoingUp = true;
			}
        }
    }

	public void ChangeImage2() // Just until we can combine the two methods together. For time being, si es como si es.
	{
		if (isStraight == false && isT == false && isCorner == false) // if no equipment is selected
		{
			if (b2.image.sprite == pipeOn)
			{
				b2.image.sprite = pipeOff;
				buttonUp2.image.sprite = straightUnpowered;
			}
			else
			{
				b2.image.sprite = pipeOff;
				buttonUp2.image.sprite = straightUnpowered;
			}
		}
		else if (isStraight == true && isT == false && isCorner == false) // if the straight piece is selected
		{
			if (b2.image.sprite == pipeOn || b2.image.sprite == pipeOff)
			{
				b2.image.sprite = straightPipe;
				isStraight = false;
				buttonUp2.image.sprite = straightUnpowered;
			}
		}
		if (isStraight == false && isT == true && isCorner == false) // if the T-piece is selected
		{
			if (b2.image.sprite == pipeOn || b2.image.sprite == pipeOff)
			{
				b2.image.sprite = tPipe;
				isT = false;
				if (powerGoingUp == true)
				{
					buttonUp2.image.sprite = straightPipe;
				}
				else if (powerGoingUp == false)
				{
					buttonUp2.image.sprite = straightUnpowered;
				}
			}
		}
		if (isStraight == false && isT == false && isCorner == true) // if the Elbow is selected
		{
			if (b2.image.sprite == pipeOn || b2.image.sprite == pipeOff)
			{
				b2.image.sprite = cornerPipe;
				isCorner = false;
				if (powerGoingUp == true)
				{
					buttonUp2.image.sprite = straightPipe;
					HackSuccessful();
				}
				else if (powerGoingUp == false)
				{
					buttonUp2.image.sprite = straightUnpowered;
				}
			}
		}
	}

	public void SelectStraight()
    {
        isStraight = true;
		Debug.Log("Straight piece selected");
    }

    public void SelectT()
    {
        isT = true;
		Debug.Log("T piece selected");
    }

    public void SelectCorner()
    {
        isCorner = true;
		Debug.Log("Corner selected");
    }

	private void HackSuccessful()
	{
		audioSource.Play();
		hackSuccessful.enabled = true;
		StartCoroutine(HackCompleted());
	}

	IEnumerator HackCompleted()
	{
		yield return new WaitForSeconds(2.5f);
        hackingCanvas.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        hudCanvas.enabled = true;
        fpsController.enabled = true;
        //redCardTrigger.SetActive(true);
    }
}
