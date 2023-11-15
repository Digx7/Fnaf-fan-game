using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableTrigger : MonoBehaviour
{
    public bool _enabled = true;
    public Material unselected;
    public Material selected;
    public UnityEvent OnSelected;
    
    private bool interactable = false;
    private MeshRenderer meshRenderer;

    public void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    
    public void isInteractable(bool state)
    {
        if(!_enabled) return;

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

    public void Enable(bool state)
    {
        _enabled = state;
    }

    public void Update()
    {
        if(interactable && Input.GetButtonDown("Fire1"))
        {
            OnSelected.Invoke();
        }
    }
}
