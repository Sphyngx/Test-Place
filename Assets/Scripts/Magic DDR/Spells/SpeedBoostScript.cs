using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : Spell
{
    WASD3rd WASD;
    
    bool Used = false;
    [SerializeField] float LifeSpan;
    [SerializeField] float SpeedBoost;
    void Start()
    {
        WASD = Player.GetComponent<WASD3rd>();
    }
    void Update()
    {
        
        if (!Used)
        {
            WASD.Speed += SpeedBoost;
            Used = true;
        }
        else
        {
            LifeSpan -= Time.deltaTime;
        }
        if (LifeSpan <= 0)
        {
            WASD.Speed -= SpeedBoost;
            Destroy(gameObject);
        }
        
    }
}
