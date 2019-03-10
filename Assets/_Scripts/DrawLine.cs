using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    LineRenderer lr;
    [SerializeField]LayerMask planetLayer = 9;
    [SerializeField] float DrawLength = 50f;
    Orbit playerOrbit;
    public Planet TargetPlanet = null;
    public bool Traveling = false;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        playerOrbit = GetComponentInParent<Orbit>();
    }

    // Update is called once per frame
    void Update()
    {
 

        if (!Traveling) {
            lr.enabled = true;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, DrawLength, planetLayer);

            lr.SetPosition(0, transform.position);
            

            if (hit.collider != null) {
                lr.SetPosition(1, hit.point);
                TargetPlanet = hit.collider.GetComponent<Planet>(); // THIS should never be null.. i think
                //TODO instantiate an effect here
            }
            else {
                //lr.SetPosition(1, transform.up * 100);
                lr.SetPosition(1, Camera.main.ScreenToWorldPoint( Input.mousePosition));
                TargetPlanet = null;
            }
            
            //lr.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else {
            lr.enabled = false;
        }
    }
}
