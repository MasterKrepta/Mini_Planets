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

    public Resource resource;

    [SerializeField] List<GameObject> obsInOrbit = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        int rand = Random.Range(0, PossibleColors.Length);
        planetColor = PossibleColors[rand];
        GetComponent<SpriteRenderer>().color = planetColor;
        ringColor = new Color(planetColor.r, planetColor.g, planetColor.b, 0.5f);

        orbitRing.color = ringColor;
        resource = GetComponent<Resource>();
        AssignResource(rand);

        float theScale = transform.localScale.x;
        distToPlanet = GetComponent<CircleCollider2D>().radius * theScale + orbitOffset;
        collider = GetComponent<CircleCollider2D>();
    }


    void AssignResource(int value) {
        switch (value) {
            case 0:
                resource.Type = Resource.Types.HULL;
                resource.Init();
                break;
            case 1:
                resource.Type = Resource.Types.ENERGY;
                resource.Init();
                break;
            case 2:
                resource.Type = Resource.Types.FUEL;
                resource.Init();
                break;
            case 3:
                resource.Type = Resource.Types.FOOD;
                resource.Init();
                break;
            default:
                resource.Type = Resource.Types.FUEL;
                resource.Init();
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") || collision.CompareTag("Obstacle")) {
            //Debug.Log("enterTrigger on planet " + this.name);
            //ToggleCollider();
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // stop movemen
            collision.transform.rotation = Quaternion.Euler(Vector3.zero);
            
            collision.GetComponent<Orbit>().BodyToOrbit = this; // begin orbit
            StatsManager.OnEnterOrbit();
            resource.GiveResource();
        }
    }
    //public void ToggleCollider() {
    //    collider.enabled = !collider.enabled;
    //}
}
