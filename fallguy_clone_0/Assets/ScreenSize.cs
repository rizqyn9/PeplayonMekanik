using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    public void Windowed()
    {
        Screen.SetResolution(960, 540, false);
    }

    public void FullScren()
    {
        Screen.SetResolution(1920, 1080, true);
    }
}