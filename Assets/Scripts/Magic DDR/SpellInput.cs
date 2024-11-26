using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpellInput : MonoBehaviour
{
    [SerializeField] SpellIdentifier identifier;

    List<string> confirmedRunes = new List<string>();
    string currentRune = "";

    [SerializeField] bool acceptingInput = false;
    [SerializeField] bool savingRune = false;
    [SerializeField] KeyCode[] runeInputs;

    void HandleInput()
    {
        if(Input.GetMouseButtonDown(0) && savingRune)
        {
            confirmedRunes.Add(currentRune);
            currentRune = string.Empty;
        }
        else if(Input.GetMouseButtonDown(0))
        {
            Spell toCast = identifier.FindSpell(confirmedRunes.ToArray());
            if(toCast)
            {
                Debug.Log("Got spell " + toCast.name);
            }
            else
            {
                Debug.Log("Broken rune!");
            }

            acceptingInput = false;
            return;
        }

        if (Input.GetMouseButton(1))
        {
            ClearInput();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            savingRune = !savingRune;
        }

        foreach(KeyCode key in runeInputs)
        {
            if(Input.GetKeyDown(key))
            {
                currentRune += ((char)key);
            }
        }
    }

    void ClearInput()
    {
        confirmedRunes.Clear();
        currentRune = string.Empty;
    }

    void Update()
    {
        if (acceptingInput)
        {
            HandleInput();
        }

        
        if(Input.GetKeyDown(KeyCode.R))
        {
            acceptingInput = !acceptingInput;

            if (!acceptingInput)
            {
                ClearInput();
            }
        }
    }
}
