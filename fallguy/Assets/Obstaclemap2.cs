using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclemap2 : MonoBehaviour
{
    public static Obstaclemap2 instance;

    [SerializeField]
    private List<Obstacle3> one = new List<Obstacle3>();

    private void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allObjects)
        {
            if (go.CompareTag("obstacle3"))
            {
                Obstacle3 ob = go.GetComponent<Obstacle3>();
                if (ob.index == 1)
                {
                    one.Add(ob);
                }
            }
        }
    }

    private void SetTrap()
    {
    }

    private void Update()
    {
    }
}