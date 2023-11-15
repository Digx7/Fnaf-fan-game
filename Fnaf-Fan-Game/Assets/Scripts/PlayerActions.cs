using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerActions : MonoBehaviour
{
    public UnityEvent OnPickUpPhone;
    public UnityEvent OnPutDownPhone;
    public UnityEvent OnStartChargingPhone;
    public UnityEvent OnStopChargingPhone;
    public UnityEvent OnTurnOnFlashLight;
    public UnityEvent OnTurnOffFlashLight;


    public void PickUpPhone()
    {
        OnPickUpPhone.Invoke();
    }

    public void PutDownPhone()
    {
        OnPutDownPhone.Invoke();
    }

    public void StartChargingPhone()
    {
        OnStartChargingPhone.Invoke();
    }

    public void StopChargingPhone()
    {
        OnStopChargingPhone.Invoke();
    }

    public void PullOutFlashLight()
    {
        OnTurnOnFlashLight.Invoke();
    }

    public void PutAwayFlashLight()
    {
        OnTurnOffFlashLight.Invoke();
    }
}
