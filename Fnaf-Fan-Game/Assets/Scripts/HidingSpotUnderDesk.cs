using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HidingSpotUnderDesk : MonoBehaviour
{
    public UnityEvent OnSelected;
    private bool interactable = false;
    
    public void isInteractable(bool state)
    {
        interactable = state;
    }

    public void Update()
    {
        if(interactable && Input.GetButtonDown("Fire1"))
        {
            OnSelected.Invoke();
        }
    }
}
