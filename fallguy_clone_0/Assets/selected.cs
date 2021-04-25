using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected : MonoBehaviour
{
    private Animator anim;
    public bool setSelected;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (setSelected)
        {
            anim.SetBool("Selected", true);
            setSelected = false;
        }
        else
        {
            anim.SetBool("Selected", false);
        }
    }
}