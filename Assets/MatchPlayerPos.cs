﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPlayerPos : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position;
        
    }
}
