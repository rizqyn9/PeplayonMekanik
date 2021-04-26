using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclemap22 : MonoBehaviour
{
    public GameObject Stone;
    public Transform[] point;
    public float Countdown;
    private float fixCoundown;

    private void Start()
    {
        fixCoundown = Countdown;
    }

    private void Update()
    {
        Countdown = Countdown - Time.deltaTime;
        if (Countdown <= 0)
        {
            int random = Random.Range(0, 3);

            Instantiate(Stone, point[random].position, Quaternion.identity);
            Countdown = fixCoundown;
            return;
        }
    }
}