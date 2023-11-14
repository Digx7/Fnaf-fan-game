using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhoneAsFlashLight : MonoBehaviour
{
    public UnityEvent OnPutFlashLightAway;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1")) OnPutFlashLightAway.Invoke();
    }
}
