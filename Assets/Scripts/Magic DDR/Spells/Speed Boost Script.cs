using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    GameObject Player;
    //WASD WASD;
    [SerializeField] float SpeedBoost;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //WASD = Player.GetComponent<WASD>();
    }
    void Update()
    {
        //WASD.Speed * SpeedBoost
    }
}
