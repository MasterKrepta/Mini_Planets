using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] DrawLine DrawLine;
    [SerializeField] float MoveSpeed = 2f;
    Rigidbody2D rb;
    [SerializeField]Planet TargetPlanet = null;
    CircleCollider2D collider2D;
    Orbit orbit;
    // Start is called before the first frame update
    void Start()
    {
        StatsManager.OnGameOver += DisableOnGameOver;
        DrawLine = GetComponentInChildren<DrawLine>();
        collider2D = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        orbit = GetComponent<Orbit>();
    }

    // Update is called once per frame
    void Update()
    {
        TargetPlanet = DrawLine.TargetPlanet;

        if (TargetPlanet != null && Input.GetMouseButtonDown(0)) {
            if (TargetPlanet == orbit.BodyToOrbit) {
                return;
            }
            orbit.LeaveOrbit();
            collider2D.enabled = false;
            StartCoroutine(ColliderDelay());

            DrawLine.Traveling = true;
            orbit.BodyToOrbit = null;
        }
        if (DrawLine.Traveling) {
            Vector2 targetPos = transform.position = Vector2.MoveTowards(transform.position, TargetPlanet.transform.position, MoveSpeed * Time.deltaTime);

            rb.velocity = transform.right * MoveSpeed * Time.deltaTime;
        }
    }

    IEnumerator ColliderDelay() {
        yield return new WaitForSeconds(.3f);
        collider2D.enabled = true;

    }

    void DisableOnGameOver() {
        this.enabled = false;
        DrawLine.enabled = false;
    }

    private void OnDisable() {
        StatsManager.OnGameOver -= DisableOnGameOver;
    }
}
