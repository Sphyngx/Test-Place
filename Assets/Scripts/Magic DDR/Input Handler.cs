using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    SpellHandler SpellHandler;
    public GameObject PlayerBody;
    [Header("Cast Stages")]
    public float InputTimer;
    public bool CanCast;
    public bool IsCast;
    public bool FinishCast;
    string Spellname;
    [Header("Input Bools")]
    public bool Input1;
    public bool Input2;
    public bool Input3;
    public bool Input4;
    public bool Input5;
    [Header("Materials")]
    public Material Default;
    public Material StartCast;
    public Material Casting;
    public Material FinishedCast;



    private void Start()
    {
        SpellHandler = GetComponent<SpellHandler>();
        CanCast = true;
    }
    void Update()
    {
        //Start casting
        if (Input.GetKeyDown(KeyCode.E) && CanCast)
        {
            Debug.Log("Started Cast");
            PlayerBody.GetComponent<Renderer>().material = StartCast;
            IsCast = true;
            CanCast = false;
        }
        //Cancel casting
        if (Input.GetMouseButtonDown(1) && IsCast)
        {
            Debug.Log("Canceled Casting");
            PlayerBody.GetComponent<Renderer>().material = Default;
            IsCast = false;
            CanCast = true;
        }
        //Cast "Flare"
        if (Input.GetKeyDown(KeyCode.R) && IsCast)
        {
            Debug.Log("Casting a spell");
            Input1 = true;
            PlayerBody.GetComponent<Renderer>().material = Casting;
            InputTimer -= Time.deltaTime;
            
        }
        if (Input.GetKeyDown(KeyCode.F) && InputTimer > 0 && Input1 == true)
        {
            Spellname = "Flare";
            Debug.Log("Finished Casting:" + Spellname);
            FinishCast = true;
            PlayerBody.GetComponent<Renderer>().material = FinishedCast;
                
                
        }
        if (Input.GetMouseButtonDown(0) && FinishCast)
        {
            InputTimer = 10;
            Input1 = false;
            IsCast = false;
            CanCast = true;
            FinishCast = false;
            Debug.Log(Spellname + " was Cast");
            PlayerBody.GetComponent<Renderer>().material = Default;
            SpellHandler.Flare();
        }
    }
}
