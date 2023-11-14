using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    
    private float distance = 10;
    
    private Vector3 origin;

    private RaycastHit hit;

    private GameObject lastObjectSeen;

    private void Start()
    {
        origin = transform.position;
        lastObjectSeen = null;
    }

    private void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        if(Physics.Raycast(origin, fwd, out hit, distance))
        {
            Debug.Log("Looking at " + hit.collider.gameObject.name + 
            "\nWith tag " + hit.collider.gameObject.tag);

            if(hit.collider.gameObject != lastObjectSeen)            // Keeps us from updating the same object every frame
            {
                // make lastObjectSeen uninteractable
                //      use TryGetComponent because lastObjectSeen could be NULL
                if(lastObjectSeen != null && lastObjectSeen.TryGetComponent<Interactable>(out Interactable interactable))
                {
                    interactable.IsBeingLookedAt(false);
                }
                
                // set new lastObjectSeen
                lastObjectSeen = hit.collider.gameObject;

                // Set new object interactable
                if(lastObjectSeen != null && lastObjectSeen.TryGetComponent<Interactable>(out Interactable _interactable))
                {
                    _interactable.IsBeingLookedAt(true);
                }
            }


        }

        Debug.DrawRay(origin, (fwd * distance));
    }
}
