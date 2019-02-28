using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    Rigidbody2D rb;
    public Planet BodyToOrbit;
    [SerializeField] float baseMoveSpeed = 1f;
    DrawLine DrawLine;
    [SerializeField] GameObject Thrusters;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StatsManager.OnEnterOrbit += EnterOrbit;
        
        try {
            DrawLine = GetComponentInChildren<DrawLine>();
        }
        catch (Exception) {
        }
        
        rb = GetComponent<Rigidbody2D>();
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
        if (DrawLine != null) {
            DrawLine.Traveling = false;
        }
        
        transform.RotateAround(BodyToOrbit.transform.position, Vector3.forward, (BodyToOrbit.OrbitalSpeedModifier + baseMoveSpeed) * Time.deltaTime);
    }

    void EnterOrbit() {
        Thrusters.SetActive(false);
        StatsManager.IncreaseResource(BodyToOrbit.resource);
    }

    public void LeaveOrbit() {
        print("Leaving Orbit");
        Thrusters.SetActive(true);
        StatsManager.OnLeaveOrbit();
        //BodyToOrbit.GetComponent<Planet>().ToggleCollider();
    }

    private void OnDisable() {
        StatsManager.OnEnterOrbit -= EnterOrbit;
    }
}
