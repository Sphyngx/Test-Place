using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertPrefabHandler : MonoBehaviour
{
    public float Timer = 4f;
    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0) 
        {
            Destroy(gameObject);
            Timer = 4f;
        }
    }
}
