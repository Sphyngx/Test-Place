using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public GameObject Player;
    public GameObject OrientationX;
    public GameObject OrientationY;
    public float ManaCost;
    public float Damage;
    public float WindUp;
    void Start()
    {
        PlayerManager.MP -= ManaCost;
    }
    void Update()
    {
        
    }
}
