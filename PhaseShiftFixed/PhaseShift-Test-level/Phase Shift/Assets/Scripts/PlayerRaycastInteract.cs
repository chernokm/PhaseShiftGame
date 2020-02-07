using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastInteract : MonoBehaviour
{
    [Header("How close does the player need to be interact with objects, in meters")]
    [SerializeField] private float maxInteractDistance = 2f;
    [SerializeField] private UnityEngine.UI.Text interactText;

    private enum LookStates { Nothing, IsLookingAtObject, LostObject }
    private LookStates currentState;

    private DoorEvents interactObject;
    private ItemEvents itemEvent;
    private MissionSelector missionSelect;
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
        CastRay();
    }

    private void CastRay() // Then apply to all other interactables, then make sensible comments!!
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward); // Casts a ray from the forward center of camera

        switch (currentState) // Further behavior depends on what the lookstate is currently doing
        {
            case LookStates.Nothing:
                ObjectCatchesRay(ray);
                break;

            case LookStates.IsLookingAtObject:
                EnableAndDisableUIPrompt(ray);
                break;

            case LookStates.LostObject:
                EmptyInteractTextAndObjects();
                currentState = LookStates.Nothing; // When the player loses focus on the object, the state turns to "lose object" and empties the interact text. Immediately changing the state the very next frame makes it so the interact text only empties once, the frame when the player stops focusing on said object
                break;
        }
    }

    private void ObjectCatchesRay(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxInteractDistance)) // When the casted out ray with limited distance var (maxInteractDis) hits something
        {
            switch (hit.collider.transform.tag) // What the ray is hitting. ie, what the player is looking at within Interact distance. This is tag based.
            {                
                case "Interact": // If the object's tag is "Interact"
                case "Mission Select":
                case "Pickup": // Or mushroom
                    AssignInteractiveObject(hit);                    
                    break;
            }
        }
    }

    private void EmptyInteractTextAndObjects()
    {
        interactText.text = "";
        interactObject = null;
        itemEvent = null;
        missionSelect = null;
    }

    private void EnableAndDisableUIPrompt(Ray ray)
    {
        RaycastHit hit;
        if (Input.GetButtonDown("Interact"))
        {
            if (interactObject)
            {
                interactObject.Pickup();
            }
            else if (itemEvent)
            {
                itemEvent.Pickup();
            }
            else if (missionSelect)
            {
                missionSelect.OpenMenu();
            }
        }

        if (Physics.Raycast(ray, out hit, maxInteractDistance))
        {
            if (hit.transform.tag == "Untagged")
            {                
                currentState = LookStates.LostObject;
            }
        }
        else
        {
            currentState = LookStates.LostObject;
        }
    }

    private void AssignInteractiveObject(RaycastHit hit)
    {
        currentState = LookStates.IsLookingAtObject;
        switch (hit.transform.tag)
        {
            case "Interact":
                interactObject = hit.collider.gameObject.GetComponent<DoorEvents>(); // When the ray catches an interactive object, the unassigned DoorEvents var of this class gets assigned to that object. This only happens one frame when the player focuses on an object.
                interactObject.ShowUIText();
                break;
            case "Pickup":
                itemEvent = hit.collider.gameObject.GetComponent<ItemEvents>();
                itemEvent.ShowUIPrompt();
                break;
            case "Mission Select":
                missionSelect = hit.collider.gameObject.GetComponent<MissionSelector>();
                missionSelect.ShowUIPrompt();
                break;
        }        
    }
}
