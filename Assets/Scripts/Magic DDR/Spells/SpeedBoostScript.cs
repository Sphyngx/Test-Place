using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : Spell
{
    GameObject Player;
    WASD3rd WASD;
    bool Boosted = false;
    [SerializeField] float Timer;
    [SerializeField] float SpeedBoost;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        WASD = Player.GetComponent<WASD3rd>();
    }
    void Update()
    {
        
        if (!Boosted)
        {
            WASD.Speed += SpeedBoost;
            Boosted = true;
        }
        else
        {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0)
        {
            WASD.Speed -= SpeedBoost;
            Destroy(gameObject);
        }
        
    }
}
