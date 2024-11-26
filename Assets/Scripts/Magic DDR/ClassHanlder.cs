using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClassHandler : MonoBehaviour
{
    //MeleeWeapons
    [System.Serializable]
    public class MeleeWeapon
    {
        public string Name;
        public int Damage;
    }

    public List<MeleeWeapon> Weapons = new List<MeleeWeapon>();
    //Spells
    [System.Serializable]
    public class Spell
    {
        public string Name;
        public string[] Runes = new string[6];
        public int Damage;
        public string Key;
        public string Value;

    }
    public List<Spell> Spells = new List<Spell>();
    Dictionary<string, Spell> test = new Dictionary<string, Spell>();
    void Start()
    {
        for (int i = 0; i < Spells.Count; i++)
        {
            test.Add(Spells[i].Key, Spells[i]);
            
        }
    }
}




