using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] DrawLine DrawLine;
    [SerializeField] float MoveSpeed = 2f;
    Rigidbody2D rb;
    Planet TargetPlanet = null;
    Orbit orbit;
    // Start is called before the first frame update
    void Start()
    {
        DrawLine = GetComponentInChildren<DrawLine>();
        rb = GetComponent<Rigidbody2D>();
        orbit = GetComponent<Orbit>();
    }

    // Update is called once per frame
    void Update()
    {
        TargetPlanet = DrawLine.TargetPlanet;

        if (TargetPlanet != null && Input.GetMouseButtonDown(0)) {
            DrawLine.Traveling = true;
            orbit.BodyToOrbit = null;
            
        }
        if (DrawLine.Traveling) {
            Vector2 targetPos = transform.position = Vector2.MoveTowards(transform.position, TargetPlanet.transform.position, MoveSpeed * Time.deltaTime);

            rb.velocity = transform.right * MoveSpeed * Time.deltaTime;
        }
    }
}
