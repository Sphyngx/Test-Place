using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject Player;
    public int ManaCost;
    public float WindUp;
    public bool WindUpStun;
    private void Start()
    {
        if (WindUpStun)
        {
            WASDImproved Movement = Player.GetComponent<WASDImproved>();
            Movement.enabled = false;
        }
    }
    private void Update()
    {
        if (WindUpStun)
        {
            WindUp -= Time.deltaTime;
            if (WindUp <= 0)
            {
                WindUpStun = false;
            }
        }
    }
}
