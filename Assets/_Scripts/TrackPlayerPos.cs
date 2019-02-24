using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerPos : MonoBehaviour
{
    [SerializeField] Orbit player;
    Vector3 offset = new Vector3(0, 0, -10f);

    void Update()
    {
        if (player.BodyToOrbit != null) {
            float distance = Vector3.Distance(player.BodyToOrbit.transform.position + offset,transform.position);
            transform.position = Vector3.Lerp(transform.position, player.BodyToOrbit.transform.position + offset, distance);
            
        }
    }
}