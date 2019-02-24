using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePs = Camera.main.ScreenToWorldPoint( Input.mousePosition);

        Vector2 dir = new Vector2(mousePs.x - transform.position.x, mousePs.y - transform.position.y);

        transform.up = dir;
    }
}
