using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StalkerAI : MonoBehaviour
{
    VisionAI VisionAI;
    RoamAI RoamAI;
    
    void Start()
    {
        VisionAI = GetComponent<VisionAI>();
        RoamAI = GetComponent<RoamAI>();
    }
    void Update()
    {
        if (VisionAI.SeeingPlayer == true)
        {
            Stalk();
        }
    }
    void Stalk()
    {

    }
}
