using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tes : MonoBehaviour

{
    private Rigidbody rb;
    public GameObject n;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + input * Time.deltaTime * speed);
    }
}