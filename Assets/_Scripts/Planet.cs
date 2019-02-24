using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    
    public float OrbitalSpeedModifier = 1f;
    [SerializeField] List<GameObject> obsInOrbit = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // stop movemen
            collision.transform.rotation = Quaternion.Euler(Vector3.zero);
            collision.GetComponent<Orbit>().BodyToOrbit = this; // begin orbit
        }
    }
}
