using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Assets.Classes;

public class InputHandler : MonoBehaviour
{
    SpellHandler SpellHandler;
    public GameObject PlayerModel;
    [Header("Cast Stages")]
    public float InputTime;
    public float InputTimer;
    public bool CanCast;
    public bool IsCast;
    public bool FinishCast;
    public string Inputs;
    int InputAmount;
    int RuneAmount;
    string BrokenRune = "BrokenRune";
    public string[] Runes = new string[6];
    public string[] SpellNames = new string[0];
    public string[] SpellInputs = new string[0];
    [Header("Flare")]
    string FlareRune = "FlareRune";
    [Header("Fireball")]
    string FireballRune = "FireballRune";
    [Header("HollowPurple")]
    string HollowPurpleRune = "HollowPurpleRune";

    [SerializeField]
    KeyCode[] spellKeys;
    private void Start()
    {
        SpellHandler = GetComponent<SpellHandler>();
        for (int i = 0; i < SpellInputs.Length; i++)
        {
            Spells spells = new Spells(SpellNames[i], SpellInputs[i]);
        }
        
        CanCast = true;
    }
    void Update()
    {
        if (InputAmount >= 1 && !FinishCast)
        {
            InputTimer -= Time.deltaTime;
        }
        //Start casting
        if (Input.GetKeyDown(KeyCode.E) && CanCast)
        {
            StartCastVoid();
        }
        //Mouse 1
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse1");
            if (!FinishCast && !IsCast)
            {
                //Melee
            }
            if (!FinishCast && IsCast)
            {
                //Create Rune
                SpellRune();
                ModifierRune();
            }
            else if (FinishCast)
            {
                //Fire Spell
                FireSpell();
            }
        }
        //Mouse 2
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse2");
            if (!FinishCast &&  !IsCast)
            {
                //Parry
            }
            else if (FinishCast || IsCast)
            {
                CancelCastVoid();
            }
            else
            {
                Debug.Log("Mouse 2 was null");
            }
        }
        if (InputTimer <= 0)
        {
            Runes[RuneAmount] += BrokenRune;
            RuneAmount++;
            ResetBools(false);
        }

        foreach(KeyCode key in spellKeys)
        {
            if(Input.GetKeyDown(key) && IsCast)
            {
                Debug.Log(key.ToString());
                Inputs += key;
                InputAmount = Inputs.Length;
            }
        }
    }
    void StartCastVoid()
    {
        Debug.Log("Started Cast");
        IsCast = true;
        CanCast = false;
        FinishCast = false;
        Inputs = null;
        InputAmount = 0;
    }
    void CancelCastVoid()
    {
        Debug.Log("Canceled Casting");
        CanCast = true;
        IsCast = false;
        FinishCast = false;
        Inputs = null;
        RuneAmount = 0;
        Array.Clear(Runes, 0, Runes.Length);
        InputAmount = 0;
        InputTimer = InputTime;
    }
    void SpellRune()
    {
        for (int i = 0; Runes.Length > i; i++)
        {
            if (string.IsNullOrEmpty(Runes[i]))
            {
                Debug.Log("Spellrune");
                //Fire "Flare"
                if (Inputs == "RFF" && InputTimer >= 0)
                {
                    Debug.Log("Flare Rune");
                    Runes[RuneAmount] += FlareRune;
                    RuneAmount++;
                    ResetBools(false);
                    break;
                }
                //Fire "Hollowpurple"
                if (Inputs == "BBFVVGGT" && InputTimer >= 0 && Input.GetMouseButtonDown(0))
                {
                    ResetBools(false);
                    break;
                }
                BreakRune();
            }
            break;
        }
    }
    void ModifierRune()
    {
        
        for (int i = 0; Runes.Length > i; i++)
        {
            Debug.Log("Runes " +Runes[i]);
            if (!Runes[i].Contains("Runes"))
            {
                Debug.Log("ModifierRune");
                //Fireball
                if (Runes.Any(s => s.Contains(FlareRune)) && Inputs == "TTF")
                {
                    Debug.Log("Fireball rune");
                    Runes[RuneAmount] += FireballRune;
                    RuneAmount++;
                    ResetBools(false);
                    break;
                }
                break;
            }
            BreakRune();
        }
        
    }
    void FireSpell()
    {
        for (int i = 0; Runes.Length > i; i++)
        {
            if (!Runes[i].Contains(BrokenRune))
            {
                Debug.Log("FireSpell");
                //Flare
                if (Runes.Any(s => s.Contains(FlareRune)))
                {
                    //Fireball
                    if (Runes.Any(s => s.Contains(FireballRune)))
                    {
                        Debug.Log("FireBall");
                        SpellHandler.Fireball();
                        ResetBools(true);
                    }
                    else
                    {
                        Debug.Log("Flare");
                        SpellHandler.Flare();
                        ResetBools(true);
                    }
                }
                ResetBools(true);
            }
            break;
        }
        ResetBools(true);
    }
    void BreakRune()
    {
        Debug.Log("The rune was Broken");
        CanCast = true;
        IsCast = false;
        FinishCast = true;
        Inputs = null;
        InputAmount = 0;
        InputTimer = InputTime;
        Runes[RuneAmount] += BrokenRune;
        RuneAmount++;
    }
    void ResetBools(bool Fullreset)
    {
        if (Fullreset)
        {
            Debug.Log("ResetBools");
            CanCast = true;
            IsCast = false;
            FinishCast = false;
            Inputs = null;
            RuneAmount = 0;
            for (int i = 0; Runes.Length > i; i++)
            {
                Runes[i] = string.Empty;
            }
            InputAmount = 0;
            InputTimer = InputTime;
            return;
        }
        else
        {
            Debug.Log("ResetBools");
            CanCast = true;
            IsCast = false;
            FinishCast = true;
            Inputs = null;        
            InputAmount = 0;
            InputTimer = InputTime;
        }
    }
}