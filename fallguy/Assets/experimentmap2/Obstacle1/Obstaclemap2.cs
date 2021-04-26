using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclemap2 : MonoBehaviour
{
    public static Obstaclemap2 instance;
    private bool colapse = true;
    public int randomvalue;

    [SerializeField]
    private List<Obstacle3> one = new List<Obstacle3>();

    private void Awake()
    {
        Obstaclemap2.instance = this;
    }

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
        for (int i = 0; i < one.Count; i++)
        {
            BoxCollider obs = one[i].gameObject.GetComponent<BoxCollider>();
            Debug.Log(one[i]);
            randomvalue = UnityEngine.Random.Range(0, 2);
            if (randomvalue == 0)
            {
                one[i].trap = true;
                one[i].indexlist = i;
                obs.isTrigger = true;
                Debug.Log("true");
            }
            else
            {
                obs.isTrigger = false;
                Debug.Log("false");
            }
            Debug.Log(randomvalue);
        }
        Debug.Log(one.Count);
    }

    private void Update()
    {
        if (colapse)
        {
            SetTrap();
            colapse = false;
        }
    }

    public void DestroyList(int index)
    {
        one.Remove(one[index]);
        Debug.Log("Remove");
    }
}