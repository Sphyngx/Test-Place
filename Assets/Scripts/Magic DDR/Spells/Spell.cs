using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject Player;
    public GameObject OrientationX;
    public GameObject OrientationY;
    public int ManaCost;
    public float WindUp;
    void Start()
    {
        OrientationY = Player.transform.Find("OrientationY").gameObject;
        OrientationX = Player.transform.Find("OrientationX").gameObject;
    }
    void Update()
    {
        
    }
}
