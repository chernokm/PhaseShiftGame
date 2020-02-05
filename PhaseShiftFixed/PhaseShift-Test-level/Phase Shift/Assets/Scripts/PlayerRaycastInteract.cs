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
                    AssignInteractiveObject(hit);
                    currentState = LookStates.IsLookingAtObject;
                    break;
            }
        }
    }

    private void EnableAndDisableUIPrompt(Ray ray)
    {
        RaycastHit hit;
        if (Input.GetButtonDown("Interact"))
        {
            interactObject.Pickup();
        }
        if (!Physics.Raycast(ray, out hit, maxInteractDistance)) // If the player stop looking at interactive object, interact text empties out once then this method stops executing until another object is found
        {
            currentState = LookStates.LostObject;
            interactText.text = "";
        }
    }

    private void AssignInteractiveObject(RaycastHit hit)
    {
        interactObject = hit.collider.gameObject.GetComponent<DoorEvents>(); // When the ray catches an interactive object, the unassigned DoorEvents var of this class gets assigned to that object. This only happens one frame when the player focuses on an object.
        interactObject.ShowUIText();
    }
}
