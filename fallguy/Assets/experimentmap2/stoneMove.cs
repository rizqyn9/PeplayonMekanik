using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private bool colapse;
    public int index;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!colapse)
        {
            if (index == 1)
            {
                rb.velocity = Vector3.right * speed;
                colapse = true;
            }
            else if (index == 2)
            {
                rb.velocity = -Vector3.right * speed;
                colapse = true;
            }
        }
    }
}