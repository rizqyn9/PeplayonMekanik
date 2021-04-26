using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DeadZone manager = GameObject.FindGameObjectWithTag("Deadzone").GetComponent<DeadZone>();
        if (other.CompareTag("Player"))
        {
            manager.currenctCheckPoint = transform.position;
        }
    }
}