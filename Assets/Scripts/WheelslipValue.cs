using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelslipValue : MonoBehaviour
{
    private WheelCollider WhellC;
    public float RoadForwardStiffness = 3f;
    public float TerrainForwardStiffness = .6f;
    public float RoadSidewaysStiffness = 1.1f;
    public float TerrainSidewaysStiffness = .2f;

    private bool Changed = false;

    private void Start()
    {
        WhellC = GetComponent<WheelCollider>();
    }

    private void Update()
    {
        if (SaveScript.OnTheRoad == true)
        {
            if (Changed == false)
            {
                Changed = true;
                WheelFrictionCurve fFriction = WhellC.forwardFriction;
                fFriction.stiffness = RoadForwardStiffness;
                WhellC.forwardFriction = fFriction;
            
                WheelFrictionCurve sFriction = WhellC.sidewaysFriction;
                sFriction.stiffness = RoadSidewaysStiffness;
                WhellC.sidewaysFriction = sFriction;
            }
        }
        
        if (SaveScript.OnTheTerrain == true)
        {
            if (Changed == true)
            {
                Changed = false;
                WheelFrictionCurve fFriction = WhellC.forwardFriction;
                fFriction.stiffness = TerrainForwardStiffness;
                WhellC.forwardFriction = fFriction;
            
                WheelFrictionCurve sFriction = WhellC.sidewaysFriction;
                sFriction.stiffness = TerrainSidewaysStiffness;
                WhellC.sidewaysFriction = sFriction;
            }
           
        }
    }
}
