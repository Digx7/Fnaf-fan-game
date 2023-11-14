using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public Vector3 AboveDeskLocation;
    public Vector3 UnderDeskLocation;
    [SerializeField] private bool isHidden = false;

    public void HideUnderDesk()
    {
        isHidden = true;

        transform.localPosition = UnderDeskLocation;
    }

    public void Update()
    {
        if(isHidden && Input.GetButtonDown("Fire1"))
        {
            isHidden = false;

            transform.localPosition = AboveDeskLocation;
        }
    }
}
