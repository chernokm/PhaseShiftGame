using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastInteract : MonoBehaviour
{
    [Header("How close does the player need to be interact with objects, in meters")]
    [SerializeField] private float maxInteractDistance = 2f;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        RaycastHit hit; // Used to store what the ray hits
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward); // Casts a ray from the forward center of camera

        if (Physics.Raycast(ray, out hit, maxInteractDistance)) // When the casted out ray with limited distance var (maxInteractDis) hits something
        {
            Debug.Log(hit.collider.transform.tag);
            switch (hit.collider.transform.tag) // What the ray is hitting. ie, what the player is looking at within Interact distance
            {
                case "Keycard":
                    hit.collider.gameObject.GetComponent<DoorEvents>().Pickup();
                    break;
            }
        }
    }
}
