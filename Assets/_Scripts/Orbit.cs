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
    bool inOrbit = false;
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
            if (!inOrbit) {
                inOrbit = true;
    
            }
            
            OrbitBody();
        }
    }

    private void OrbitBody() {
        //movement.orbiting = true;
        DrawLine.Traveling = false;

        transform.RotateAround(BodyToOrbit.transform.position, Vector3.forward, BodyToOrbit.OrbitalSpeedModifier * Time.deltaTime);

        Vector3 modifiedPos = (transform.position - BodyToOrbit.transform.position).normalized * BodyToOrbit.distToPlanet + BodyToOrbit.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, modifiedPos, Time.deltaTime * BodyToOrbit.OrbitalSpeedModifier);
        
        


    }


    public void LeaveOrbit() {
        print("Leaving Orbit");
        inOrbit = false;
        //BodyToOrbit.GetComponent<Planet>().ToggleCollider();
    }
}
