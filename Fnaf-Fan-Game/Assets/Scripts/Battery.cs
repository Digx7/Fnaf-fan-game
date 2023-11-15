using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Battery : MonoBehaviour
{
    public float maxCharge = 100f;
    [SerializeField] private float currentCharge = 100f;
    [SerializeField] private float currentUsage = 0f;
    [SerializeField] private bool phoneIsOn = false;
    [SerializeField] private float phoneOnUsage = 5f;
    [SerializeField] private bool cameraIsOn = false;
    [SerializeField] private float cameraUsage = 5f;
    [SerializeField] private bool flashLightIsOn = false;
    [SerializeField] private float flashLightUsage = 5f;
    [SerializeField] private bool messageIsOn = false;
    [SerializeField] private float messageUsage = 5f;
    [SerializeField] private float chargeRate = 10f;
    [SerializeField] private bool isPhoneDead = false;
    [SerializeField] private bool isCharging = false;

    public UnityEvent OnPhoneDead;
    public UnityEvent<float> OnCharging;
    public UnityEvent<float> OnDraining;

    public void SetCharging(bool state)
    {
        isCharging = state;
    }
    
    public void SetPhoneOn(bool state)
    {
        phoneIsOn = state;
    }

    public void SetCameraOn(bool state)
    {
        cameraIsOn = state;
    }

    public void SetFlashlightOn(bool state)
    {
        flashLightIsOn = state;
    }

    public void SetMessageOn(bool state)
    {
        messageIsOn = state;
    }

    private void CalculateUsage()
    {
        currentUsage = 0;
        if(phoneIsOn) currentUsage += phoneOnUsage;
        if(cameraIsOn) currentUsage += cameraUsage;
        if(flashLightIsOn) currentUsage += flashLightUsage;
        if(messageIsOn) currentUsage += messageUsage;
    }

    private void Update()
    {
        if(isCharging)
        {
            Charge();
        }
        else if(!isPhoneDead)
        {
            Drain();
        }
    }

    private void Drain()
    {
        CalculateUsage();
        
        currentCharge -= (currentUsage * Time.deltaTime);
        OnDraining.Invoke(currentCharge);

        if(currentCharge <= 0)
        {
            isPhoneDead = true;
            OnPhoneDead.Invoke();
        }
    }

    private void Charge()
    {
        currentCharge += (chargeRate * Time.deltaTime);
        OnCharging.Invoke(currentCharge);

        if(currentCharge >= maxCharge)
            currentCharge = maxCharge;

        if(currentCharge > 0)
        {
            isPhoneDead = false;
        }
    }


}
