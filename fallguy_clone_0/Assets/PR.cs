using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PR : MonoBehaviour
{
    public Transform target;
    public float cameraDist;
    public float cameraDista;
    public float cameraDistb;
    public Transform camera;
    public float targetSpeed;
    private float xangle;
    private float yangle;

    [SerializeField]
    private Transform pivot;

    private void Awake()
    {
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        followPlayer();
        HandleRotation(h, v);
    }

    private void followPlayer()
    {
        float speed = Time.deltaTime * 4;
        Vector3 targetpos = Vector3.Lerp(transform.position, target.position, speed);
        transform.position = targetpos;
    }

    private void HandleRotation(float v, float h)

    {
        xangle -= h * targetSpeed;

        xangle = Mathf.Clamp(xangle, -35, 35);
        pivot.localRotation = Quaternion.Euler(xangle, 0, 0);

        yangle += v * targetSpeed;
        transform.rotation = Quaternion.Euler(0, yangle, 0);
    }

    private void LateUpdate()
    {
        camera.localPosition = new Vector3(cameraDistb, cameraDista, -cameraDist);
    }
}