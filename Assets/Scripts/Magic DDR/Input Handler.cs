using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class InputHandler : MonoBehaviour
{
    [SerializeField] SpellIdentifier identifier;
    [SerializeField] bool CanCast;
    [SerializeField] bool IsCasting;
    [SerializeField] float CastTime;
    [SerializeField] float CastTimer;
    [SerializeField] string Inputs;
    [SerializeField] List<string> Runes = new List<string>();
    [SerializeField] KeyCode[] RuneInputs;

    void SpellInputs()
    {
        if (Input.GetMouseButtonDown(0) && IsCasting)
        {
            //Add save rune
            Runes.Add(Inputs);
            Inputs = string.Empty;
        }
        else if (Input.GetMouseButtonDown(0) && CanCast && !IsCasting)
        {
            //Add fire-spell
        }
        if (Input.GetMouseButtonDown(1) && IsCasting)
        {
            //Add cancell spell & inputs
        }
        if (Input.GetKeyDown(KeyCode.E) && CanCast)
        {
            //starts recording inputs
            CanCast = false;
            IsCasting = true;
            Debug.Log("Casting");
        }
        if (IsCasting && CastTimer >= 0)
        {
            //Records Inputs
            foreach (KeyCode key in RuneInputs)
            {
                if (Input.GetKeyDown(key))
                {
                    Inputs += ((char)key);
                }
            }
            //Timer for casting
            CastTimer -= Time.deltaTime;
        }
        if (CanCast)
        {
            CastTimer = CastTime;
        }
    }
    private void Update()
    {
        SpellInputs();
    }
}