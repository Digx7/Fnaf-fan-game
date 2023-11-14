using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    public float sensX;
    public Vector2 xClamp;
    public float sensY;
    public Vector2 yClamp;

    float xRotation;
    float yRotation;

    [SerializeField] private bool isOn = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(isOn) RotateOffMouse();
    }

    private void RotateOffMouse()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, xClamp.y, xClamp.x);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, yClamp.y, yClamp.x);

        // rotate cam
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    public void Reset()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void TurnOnOff(bool state)
    {
        isOn = state;

        if(isOn)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


}
