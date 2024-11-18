using System.Collections;
using System.Collections.Generic;
using Assets.Classes;
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
    public int NumOWeapons;
    public MeleeWeapon[] Weapons = new MeleeWeapon[0];
    //Spells
    [System.Serializable]
    public class Spell
    {
        public string Name;
        public string[] Runes = new string[6];
        public int Damage;
    }
    public int NumOSpells;
    public Spell[] Spells = new Spell[0];
    private void Start()
    {
        System.Array.Resize(ref Weapons, NumOWeapons);
        System.Array.Resize(ref Spells, NumOSpells);
        for (int i = 0; i < NumOWeapons; i++)
        {
            Weapons[i] = new MeleeWeapon();
        }
    }
}
