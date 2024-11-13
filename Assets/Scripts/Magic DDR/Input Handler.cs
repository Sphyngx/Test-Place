using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;

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
    public int RuneAmount;
    string BrokenRune = "BrokenRune";
    public string[] Runes = new string[6];
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
        //Cancel casting
        if (Input.GetMouseButtonDown(1))
        {
            CancelCastVoid();
        }
        //Finish casting
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse1");
            if (!FinishCast && IsCast)
            {
                SpellRune();
                ModifierRune();
            }
            else if (FinishCast)
            {
                FireSpell();
            }
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
        InputTimer = 2;
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
        InputTimer = 2;
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
            InputTimer = 2;
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
            InputTimer = 2;
        }
    }
}