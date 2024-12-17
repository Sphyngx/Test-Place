using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.WSA;

public class InputHandler : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] GameObject PlayerModel;
    [SerializeField] Transform ThrowPosition;
    [Header("Melee Inputs")]
    [SerializeField] bool Stance;
    [Header("Spell Inputs")]
    [SerializeField] SpellIdentifier identifier;
    [SerializeField] bool CanCast;
    [SerializeField] bool IsCasting;
    [SerializeField] float CastTime;
    [SerializeField] float CastTimer;
    [SerializeField] string Inputs;
    [SerializeField] List<string> Runes = new List<string>();
    [SerializeField] KeyCode[] RuneInputs;
    void MeleeInputs()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            Stance = !Stance;
        }
        if (Input.GetMouseButtonDown(0) && Stance && !IsCasting)
        {
            //m1
            Collider[] hitbox = Physics.OverlapBox(PlayerModel.transform.position + PlayerModel.transform.up * 3 - new Vector3(0, 1f), new Vector3(5,5,5));
            for (int i = 0; i < hitbox.Length; i++)
            {
                Debug.Log("Hit " + hitbox[i].name);
            }
        }
    }
    void SpellInputs()
    {
        if (Input.GetMouseButtonDown(0) && IsCasting)
        {
            if (Inputs != null && Inputs != String.Empty)
            {
                //Save rune
                Runes.Add(Inputs);
                Inputs = string.Empty;
                CanCast = true;
                IsCasting = false;
            }
        }
        else if (Input.GetMouseButtonDown(0) && CanCast && !IsCasting && Runes.Count != 0)
        {
            //Fire-spell
            Spell Search = identifier.FindSpell(Runes.ToArray());
            if (Search)
            {
                Debug.Log("Got spell " + Search.name);
                if (Search.WindUp > 0)
                {
                    StartCoroutine(WaitForWindUpStun(Search));
                }
                else
                {
                    Spell CastedSpell = Instantiate(Search, ThrowPosition.position, ThrowPosition.rotation);
                    CastedSpell.PlayerManager = playerManager;
                }
                Runes.Clear();
            }
            else
            {
                //Broken rune
                Runes.Clear();
                Debug.Log("tried to cast broken rune");
            }
        }
        if (Input.GetMouseButtonDown(1) && IsCasting)
        {
            CanCast = true;
            IsCasting = false;
            Inputs = string.Empty;
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
        if (CastTimer < 0)
        {
            CanCast = true;
            IsCasting = false;
            Inputs = string.Empty;
        }
        if (CanCast)
        {
            CastTimer = CastTime;
        }
    }
    private IEnumerator WaitForWindUpStun(Spell Search)
    {
        Search.Player = gameObject;
        float WindUpReset = Search.WindUp;
        while (Search.WindUp > 0)
        {
            Search.WindUp -= Time.deltaTime;
            yield return null; 
        }
        Spell CastedSpell = Instantiate(Search, ThrowPosition.position, ThrowPosition.rotation);
        CastedSpell.PlayerManager = playerManager;
        Search.WindUp = WindUpReset;
    }
    private void Update()
    {
        MeleeInputs();
        if (Stance)
        {
            SpellInputs();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(PlayerModel.transform.position + PlayerModel.transform.up * 3 - new Vector3(0,1f), new Vector3(5, 5, 5));
    }
}