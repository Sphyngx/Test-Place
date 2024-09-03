using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    [Header("Flare")]
    public GameObject FlarePrefab;
    GameObject FlareObject;
    public GameObject FlarePos;
    public void Flare()
    {
        Instantiate(FlarePrefab);
        FlareObject = GameObject.FindGameObjectWithTag("Flare");
        FlareObject.transform.position = FlarePos.transform.position;
    }
}
