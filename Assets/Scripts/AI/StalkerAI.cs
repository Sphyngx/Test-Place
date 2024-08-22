using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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
        RoamAI.Roam();
    }
}
