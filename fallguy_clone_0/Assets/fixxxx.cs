using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixxxx : MonoBehaviour
{
    public float TweenTimePauseMenu;
    public bool ssdasdads = false;

    private void Awake()
    {
        LeanTween.scale(this.gameObject, Vector3.one, TweenTimePauseMenu)
              .setEaseInCubic();
    }

    private void Update()
    {
        if (ssdasdads = false)
        {
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        }
    }
}