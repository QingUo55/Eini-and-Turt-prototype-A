using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEffector : MonoBehaviour
{
    public GroundType GroundType;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GroundType
{
    mud = 0,
    ice = 1,

}
