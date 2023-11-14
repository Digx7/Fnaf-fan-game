using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraFeed : MonoBehaviour
{
    public RenderTexture livingRoom;
    public RenderTexture kitchen;
    public RenderTexture balcony;
    public RawImage rawImage;
    public TextMeshProUGUI locationName;

    public void SetLivingRoom()
    {
        rawImage.texture = livingRoom;
        locationName.text = "Living Room";
    }
    public void SetKitchen()
    {
        rawImage.texture = kitchen;
        locationName.text = "Kitchen";
    }
    public void SetBalcony()
    {
        rawImage.texture = balcony;
        locationName.text = "Balcony";
    }
}