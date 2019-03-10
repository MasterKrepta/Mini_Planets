using System;
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
    [SerializeField] Sprite[] PossibleSprites;
    [SerializeField] Sprite[] ResourceSprites;
    [SerializeField] SpriteRenderer orbitRing;
    [SerializeField] SpriteRenderer ResourceIcon;
    [SerializeField] Color planetColor;
    Color ringColor;

    public Resource resource;

    [SerializeField] List<GameObject> obsInOrbit = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        
        int rand = UnityEngine.Random.Range(0, PossibleColors.Length);
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

    private void Start() {
        GetRandomSprite();
    }

    private void GetRandomSprite() {
        int r = UnityEngine.Random.Range(0, PossibleSprites.Length);
        
        this.GetComponent<SpriteRenderer>().sprite = PossibleSprites[r];
    }

    void AssignResource(int value) {
        switch (value) {
            case 0:
                resource.Type = Resource.Types.HULL;
                ResourceIcon.sprite = ResourceSprites[0];
                resource.Init();
                break;
            case 1:
                resource.Type = Resource.Types.ENERGY;
                ResourceIcon.sprite = ResourceSprites[1];
                resource.Init();
                break;
            case 2:
                resource.Type = Resource.Types.FUEL;
                ResourceIcon.sprite = ResourceSprites[2];
                resource.Init();
                break;
            case 3:
                resource.Type = Resource.Types.FOOD;
                ResourceIcon.sprite = ResourceSprites[3];
                resource.Init();
                break;
            default:
                resource.Type = Resource.Types.FUEL;
                ResourceIcon.sprite = ResourceSprites[2];
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
