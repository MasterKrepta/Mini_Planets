using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]Rigidbody2D hook;
    public bool aiming = false;
    public bool orbiting = false;
    private float releaseTime = .1f;
    float maxDistance = 2f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (orbiting) {
            hook.position = this.transform.position;
        }

        if (aiming) {
            orbiting = false;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hook.position) > maxDistance) {
                rb.position = (mousePos - hook.position).normalized * maxDistance;
            }
            else {
                rb.position = mousePos;
            }
        }
    }

    void OnMouseDown() {
        aiming = true;
        rb.isKinematic = true;
    }

    void OnMouseUp() {
        aiming = false;
        rb.isKinematic = false;
        StartCoroutine(LaunchPlayer());
    }

    IEnumerator LaunchPlayer() {
        this.enabled = false;
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
    }

    void ResetHook() {

    }
}
