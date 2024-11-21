using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Classes;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClassHandler : MonoBehaviour, ISerializationCallbackReceiver
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
    }

    private Dictionary<string, string> _Dictionary;
    [SerializeField] public List<string> _Keys;
    [SerializeField] public List<string> _Values;

    public List<Spell> Spells = new List<Spell>();
    public void OnBeforeSerialize()
    {
        _Keys = _Dictionary.Keys.ToList();
        _Values = _Dictionary.Values.ToList();
    }

    public void OnAfterDeserialize()
    {
        _Dictionary.Clear();
        _Dictionary.AddRange(_Keys.Zip(_Values, (first, second) => new KeyValuePair<string, string>(first, second)));
    }
    private void Update()
    {
        Debug.Log(_Dictionary.Keys + " " + _Dictionary.Values);
    }
}
