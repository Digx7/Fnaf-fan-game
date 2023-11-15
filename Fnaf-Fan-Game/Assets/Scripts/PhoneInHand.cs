using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneInHand : MonoBehaviour
{
    public List<TextMeshProUGUI> batterUis;
    public GameObject deadScreen;
    public GameObject lockScreen;
    public GameObject[] allAppScreens;

    private bool dead = false;
    public void SetDead(bool value) 
    { 
        dead = value; 

        deadScreen.SetActive(true);
        lockScreen.SetActive(false);

        foreach (GameObject screen in allAppScreens)
        {
            screen.SetActive(false);
        } 
    }

    public void DrawBattery(float value)
    {
        // Debug.Log("Draw Battery");
        
        foreach (TextMeshProUGUI ui in batterUis)
        {
            ui.text = "Battery " + Mathf.Round(value) + "%";
        }
    }

    public void Pickup()
    {
        if(dead)
        {
            deadScreen.SetActive(true);
        }
        else
        {
            lockScreen.SetActive(true);
        }
        
        foreach (GameObject screen in allAppScreens)
        {
            screen.SetActive(false);
        }
    }

    public void Putdown()
    {
        deadScreen.SetActive(false);
        lockScreen.SetActive(false);
        
        foreach (GameObject screen in allAppScreens)
        {
            screen.SetActive(false);
        }
    }
}
