using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    
    public float OrbitalSpeedModifier = 1f;
    public float distToPlanet = 3;
    [SerializeField] float orbitOffset = 0.2f;
    CircleCollider2D collider;
    [SerializeField] Color[] PossibleColors;
    [SerializeField] SpriteRenderer orbitRing;

    [SerializeField] Color planetColor;
    Color ringColor;

    [SerializeField] List<GameObject> obsInOrbit = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        planetColor = PossibleColors[Random.Range(0, PossibleColors.Length - 1)];
        GetComponent<SpriteRenderer>().color = planetColor;
        ringColor = new Color(planetColor.r, planetColor.g, planetColor.b, 0.5f);

        orbitRing.color = ringColor;
        

        float theScale = transform.localScale.x;
        distToPlanet = GetComponent<CircleCollider2D>().radius * theScale + orbitOffset;
        collider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") || collision.CompareTag("Obstacle")) {
            //Debug.Log("enterTrigger on planet " + this.name);
            //ToggleCollider();
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // stop movemen
            collision.transform.rotation = Quaternion.Euler(Vector3.zero);
            
            collision.GetComponent<Orbit>().BodyToOrbit = this; // begin orbit
        }
    }
    //public void ToggleCollider() {
    //    collider.enabled = !collider.enabled;
    //}
}
