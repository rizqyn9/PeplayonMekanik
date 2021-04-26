using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 3f;
    public bool obstacle1;
    public bool obstacle2;
    public bool obstacle3;
    public bool clearobstacle;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (MovableObs.ready)
        {
            if (obstacle1)
            {
                transform.Rotate(0f, 0f, speed * Time.deltaTime / 0.01f, Space.Self);
            }
            else if (obstacle2)
            {
                transform.Rotate(0f, 0f, speed * Time.deltaTime / 0.01f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (obstacle2)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("frezzerotation");
                Rigidbody rb = other.GetComponent<Rigidbody>();
                /* FixedJoint player = other.gameObject.AddComponent<FixedJoint>();
                 player.connectedBody = RenderBuffer;*/
                rb.freezeRotation = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (obstacle2)
        {
            if (other.CompareTag("Player"))
            {
                if (clearobstacle)
                {
                    Debug.Log("frezzerotation");
                    Rigidbody rb = other.GetComponent<Rigidbody>();
                    /* rb.constraints = RigidbodyConstraints.FreezeRotationX;
                     rb.constraints = RigidbodyConstraints.FreezeRotationY;
                     rb.constraints = RigidbodyConstraints.FreezeRotationZ;*/
                    rb.freezeRotation = true;
                }
            }
        }
    }
}