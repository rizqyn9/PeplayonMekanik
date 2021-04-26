using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public static Dead instance;

    public Vector3 CurrentCheckpoint;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = CurrentCheckpoint;
    }
}