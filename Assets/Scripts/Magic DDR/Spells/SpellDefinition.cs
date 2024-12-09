using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spell", menuName = "Spells")]
public class SpellDefinition : ScriptableObject
{
    public string[] runes;
    public Spell spell;

}
