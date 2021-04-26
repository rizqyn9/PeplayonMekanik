using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CR : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement.Normalize();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
        if (movement.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), 0.5f);
        }
    }
}