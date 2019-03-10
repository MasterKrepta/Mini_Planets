using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToHome : MonoBehaviour
{
    [SerializeField] GameObject Player, HomeWorld;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePs = Camera.main.ScreenToWorldPoint(HomeWorld.transform.position);

        Vector2 dir = new Vector2(mousePs.x - transform.position.x, mousePs.y - transform.position.y);

        transform.up = dir;
    }
}
