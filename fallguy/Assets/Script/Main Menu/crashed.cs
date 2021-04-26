using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashed : MonoBehaviour
{
    public AudioSource Crashed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Crashed.Play();
        }
    }
}