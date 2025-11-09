using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform transformArme;
    public float speedMove = 5f;


    void Update()
    {
        transformArme.rotation = Quaternion.LookRotation(Input.GetAxis("Horizontal") * Vector3.forward, Input.GetAxis("Vertical") * Vector3);
        Debug.Log(Input.GetAxis("_Horizontal") +  Input.GetAxis("_Verticale"));
    }
}
