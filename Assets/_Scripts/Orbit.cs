using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    Rigidbody2D rb;
    public Planet BodyToOrbit;
    DrawLine DrawLine;
    PlayerMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        DrawLine = GetComponentInChildren<DrawLine>();
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BodyToOrbit != null) {
            
            OrbitBody();
        }
    }

    private void OrbitBody() {
        //movement.orbiting = true;
        DrawLine.Traveling = false;
        
        Debug.Log("In orbit of planet " + BodyToOrbit.name);
        transform.RotateAround(BodyToOrbit.transform.position, Vector3.forward, BodyToOrbit.OrbitalSpeedModifier* Time.deltaTime);
    }
}
