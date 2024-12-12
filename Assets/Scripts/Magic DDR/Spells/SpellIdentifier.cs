using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellIdentifier : MonoBehaviour
{
    SpellDefinition[] spellDefinitions;

    // Start is called before the first frame update
    void Start()
    {
        spellDefinitions = Resources.LoadAll<SpellDefinition>("SpellDefintions/");
    }

    public Spell FindSpell(string[] runes)
    {
        List<SpellDefinition> matchingDef = new List<SpellDefinition>();
        foreach(SpellDefinition definition in spellDefinitions)
        {
            if(definition.runes.Length == runes.Length)
            {
                matchingDef.Add(definition);
            }
        }

        foreach(SpellDefinition def in matchingDef)
        {
            int matchCounter = 0;
            for(int i = 0; i < runes.Length; i++)
            {
                if (runes[i].ToLower() == def.runes[i].ToLower())
                {
                    matchCounter += 1;
                }
            }

            if(matchCounter == runes.Length)
            {
                return def.spell;
            }
        }

        return null;

    }
}
