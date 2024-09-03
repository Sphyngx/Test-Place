using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    InputHandler InputHandler;
    [Header("Flare")]
    public GameObject FlarePrefab;
    public GameObject FlareObject;
    public GameObject FlarePos;
    private void Start()
    {
        InputHandler = GetComponent<InputHandler>();
    }
    public void Flare()
    {
        Instantiate(FlarePrefab);
        FlareObject = GameObject.FindGameObjectWithTag("Flare");
        FlareObject.transform.position = FlarePos.transform.position;
        InputHandler.FinishCast = false;
    }
}
