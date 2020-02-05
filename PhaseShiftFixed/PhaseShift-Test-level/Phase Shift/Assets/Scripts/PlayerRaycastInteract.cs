using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastInteract : MonoBehaviour
{
    [Header("How close does the player need to be interact with objects, in meters")]
    [SerializeField] private float maxInteractDistance = 2f;
    [SerializeField] private UnityEngine.UI.Text interactText;

    private enum LookStates { Nothing, FoundObject, IsLookingAtObject, LostObject }
    private LookStates currentState;

    private DoorEvents interactObject;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        currentState = LookStates.Nothing;
    }

    // Update is called once per frame
    void Update()
    {
        HandleStates();
        CastRay();
    }

    private void HandleStates()
    {
        switch (currentState)
        {
            case LookStates.FoundObject:
                currentState = LookStates.IsLookingAtObject;
                break;
            case LookStates.LostObject:
                currentState = LookStates.Nothing;
                break;
        }
    }

    private void CastRay() // !! Check Efficiency!! Then apply to all other interactables, then make sensible comments!!
    {
        RaycastHit hit; // Used to store what the ray hits
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward); // Casts a ray from the forward center of camera

        switch (currentState)
        {
            case LookStates.Nothing:
                if (Physics.Raycast(ray, out hit, maxInteractDistance)) // When the casted out ray with limited distance var (maxInteractDis) hits something
                {
                    switch (hit.collider.transform.tag) // What the ray is hitting. ie, what the player is looking at within Interact distance
                    {
                        case "Interact":
                            currentState = LookStates.FoundObject;
                            SwitchToFoundObject(hit);
                            currentState = LookStates.IsLookingAtObject;
                            break;
                    }
                }
                break;
            case LookStates.IsLookingAtObject:
                if (Input.GetButtonDown("Interact"))
                {
                    interactObject.Pickup();
                }
                if (!Physics.Raycast(ray, out hit, maxInteractDistance))
                {
                    currentState = LookStates.LostObject;
                    interactText.text = "";
                }
                break;
        }
    }

    private void SwitchToFoundObject(RaycastHit hit)
    {
        interactObject = hit.collider.gameObject.GetComponent<DoorEvents>();
        if (Input.GetButtonDown("Interact"))
        {
            interactObject.Pickup();
        }
        else
        {
            interactObject.ShowUIText();
        }
    }
}
