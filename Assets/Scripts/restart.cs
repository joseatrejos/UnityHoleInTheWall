using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{

    player player;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.Find("robotModelFree").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            player.reiniciar();
        }
    }
  }

