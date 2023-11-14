using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool isBeingLookedAt = false;
    public UnityEvent<bool> OnLookedAt;

    public void IsBeingLookedAt(bool state) 
    {
        isBeingLookedAt = state;
        OnLookedAt.Invoke(state);
    }


}
