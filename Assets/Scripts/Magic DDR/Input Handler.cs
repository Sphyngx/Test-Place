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
    public string Inputs;
    public int InputAmount;
    [Header("Flare")]
    public bool FlareRune;
    [Header("Fireball")]
    public bool FireballRune;
    [Header("HollowPurple")]
    public bool HollowpurpleRune;
    private void Start()
    {
        SpellHandler = GetComponent<SpellHandler>();
        CanCast = true;
    }
    void Update()
    {
        SpellRune();
        ModifierRune();
        FireSpell();
        if (InputAmount >= 1 && !FinishCast)
        {
            InputTimer -= Time.deltaTime;
        }
        //Start casting
        if (Input.GetKeyDown(KeyCode.E) && CanCast)
        {
            StartCastVoid();
        }
        //Cancel casting
        if (Input.GetMouseButtonDown(1))
        {
            CancelCastVoid();
        }
        if (InputTimer <= 0)
        {
            CanCast = true;
            IsCast = false;
            FinishCast = false;
            Inputs = null;
            InputAmount = 0;
            InputTimer = 2;
}
        //Cast "R"
        if (Input.GetKeyDown(KeyCode.R) && IsCast)
        {
            CastR();
        }
        //Cast "T"
        if (Input.GetKeyDown(KeyCode.T) && IsCast)
        {
            CastT();
        }
        //Cast "Y"
        if (Input.GetKeyDown(KeyCode.Y) && IsCast)
        {
            CastY();
        }
        //Cast "F"
        if (Input.GetKeyDown(KeyCode.F) && IsCast)
        {
            CastF();
        }
        //Cast "G"
        if (Input.GetKeyDown(KeyCode.G) && IsCast)
        {
            CastG();
        }
        //Cast "H"
        if (Input.GetKeyDown(KeyCode.H) && IsCast)
        {
            CastH();
        }
        //Cast "C"
        if (Input.GetKeyDown(KeyCode.C) && IsCast)
        {
            CastC();
        }
        //Cast "V"
        if (Input.GetKeyDown(KeyCode.V) && IsCast)
        {
            CastV();
        }
        //Cast "B"
        if (Input.GetKeyDown(KeyCode.B) && IsCast)
        {
            CastB();
        }
    }
    void StartCastVoid()
    {
        Debug.Log("Started Cast");
        IsCast = true;
        CanCast = false;
        Inputs = null;
        InputAmount = 0;
        GameObject.Destroy(SpellHandler.FlareObject);
    }
    void CancelCastVoid()
    {
        Debug.Log("Canceled Casting");
        GameObject.Destroy(SpellHandler.FlareObject);
        CanCast = true;
        IsCast = false;
        FinishCast = false;
        Inputs = null;
        InputAmount = 0;
        InputTimer = 2;
    }
    void CastR()
    {
        Debug.Log("R");
        Inputs += "R";
        InputAmount = Inputs.Length;
    }
    void CastT()
    {
        Debug.Log("T");
        Inputs += "T";
        InputAmount = Inputs.Length;
    }
    void CastY()
    {
        Debug.Log("Y");
        Inputs += "Y";
        InputAmount = Inputs.Length;
    }
    void CastF()
    {
        Debug.Log("F");
        Inputs += "F";
        InputAmount = Inputs.Length;
    }
    void CastG()
    {
        Debug.Log("G");
        Inputs += "G";
        InputAmount = Inputs.Length;
    }
    void CastH()
    {
        Debug.Log("H");
        Inputs += "H";
        InputAmount = Inputs.Length;
    }
    void CastC()
    {
        Debug.Log("C");
        Inputs += "C";
        InputAmount = Inputs.Length;
    }
    void CastV()
    {
        Debug.Log("V");
        Inputs += "V";
        InputAmount = Inputs.Length;
    }
    void CastB()
    {
        Debug.Log("B");
        Inputs += "B";
        InputAmount = Inputs.Length;
    }
     void SpellRune()
    {
        //Fire "Flare"
        if (Inputs == "RFF" && InputTimer >= 0 && Input.GetMouseButtonDown(0))
        {
            FlareRune = true;
            SpellHandler.Fireball();
            ResetBools();
            ResetRunes();   

        }
        //Fire "Hollowpurple"
        if (Inputs == "BBFVVGGT" && InputTimer >= 0 && Input.GetMouseButtonDown(0))
        {
            HollowpurpleRune = true;
            ResetBools();
        }
    }
    void ModifierRune()
    {
        if (FlareRune == true && Inputs == "TTF" && Input.GetMouseButtonDown(0))
        {
            FireballRune = true;
            ResetBools();
        }
    }
    void FireSpell()
    {
        if (FlareRune && Input.GetMouseButtonDown(0))
        {
            SpellHandler.Flare();
            ResetRunes();  
        }
        if (FireballRune && Input.GetMouseButton(0))
        {
            SpellHandler.Fireball();
            ResetRunes();
        }
    }
    void ResetBools()
    {
        CanCast = true;
        IsCast = false;
        Inputs = null;
        InputAmount = 0;
        InputTimer = 2;
    }
    void ResetRunes()
    {
        FlareRune = false;
        FireballRune = false;
    }
}