﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Stun()
    {
        Debug.Log(name + " got stunned");
    }

    public void RecoverStun()
    {
        Debug.Log(name + " recovered stun");
    }
}
