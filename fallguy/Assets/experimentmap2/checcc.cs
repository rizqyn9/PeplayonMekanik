using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checcc : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Dead.instance.CurrentCheckpoint = transform.position;
    }
}