using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
    {
        // Increasing the number of the item by 1 each time one is collected then getting rid of the object
        Inventory.KeycardAmount += 1;
		Destroy(gameObject);
    }
}
