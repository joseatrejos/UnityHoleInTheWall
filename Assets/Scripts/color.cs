﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = Color.blue;
        print("Chocaste locoo");
        //Destroy(gameObject);

    }
}
