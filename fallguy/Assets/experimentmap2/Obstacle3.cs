using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle3 : MonoBehaviour
{
    public int index;
    public bool trap;
    public int indexlist;

    private void OnTriggerEnter(Collider other)
    {
        if (trap)
        {
            /*   Obstaclemap2.instance.DestroyList(indexlist);*/
            Destroy(gameObject);
        }
    }
}