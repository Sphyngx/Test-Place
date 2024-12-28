using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [Header("Class Inherited")]
    public PlayerManager PlayerManager;
    public GameObject Player;
    public Spell spell;
    public float ManaCost;
    public float ManaDrainMultiplier;
    public float Damage;
    public float WindUp;
    public bool ManaDrain;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerManager = Player.GetComponent<PlayerManager>();
    }
}
