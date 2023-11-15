using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhoneOnDesk : MonoBehaviour
{
    public Material unselected;
    public Material selected;
    public UnityEvent OnSelected;
    public UnityEvent OnUnselected;
    
    private bool interactable = false;
    private bool isSelected = false;
    private MeshRenderer meshRenderer;

    public void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    
    public void isInteractable(bool state)
    {
        interactable = state;

        if(interactable)
        {
            meshRenderer.material = selected;
        }
        else
        {
            meshRenderer.material = unselected;
        }
    }

    public void Update()
    {
        if(interactable && Input.GetButtonDown("Fire1") && !isSelected)
        {
            isSelected = true;
            OnSelected.Invoke();
            Debug.Log("Is Selected!");
        }
        else if (interactable && Input.GetButtonDown("Fire1") && isSelected)
        {
            isSelected = false;
            OnUnselected.Invoke();
            Debug.Log("Is Unselected!");
        }
    }

}
