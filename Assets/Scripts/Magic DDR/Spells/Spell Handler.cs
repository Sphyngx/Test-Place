using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    InputHandler InputHandler;
    public GameObject Player;
    public GameObject PlayerOrientationX;
    public GameObject PlayerOrientationY;
    [Header("Flare")]
    public GameObject FlarePrefab;
    public GameObject FlareObject;
    public GameObject FlarePos;
    [Header("Fireball")]
    public GameObject FireballPrefab;
    [Header("HollowPurple")]
    public GameObject HollowPurplaPrefab;
    
    private void Start()
    {
        InputHandler = GetComponent<InputHandler>();
    }
    public void Flare()
    {
        FlareObject = Instantiate(FlarePrefab);
        FlareObject.transform.position = FlarePos.transform.position;
        
    }
    public void Fireball()
    {
        GameObject FireballObject;
        FireballObject = Instantiate(FireballPrefab);
        Rigidbody FireballRigidbody = FireballObject.GetComponent<Rigidbody>();
        FireballObject.transform.position = Player.transform.position + PlayerOrientationX.transform.forward + PlayerOrientationY.transform.forward;
        FireballRigidbody.AddForce(PlayerOrientationX.transform.forward + PlayerOrientationY.transform.forward * 5,ForceMode.Impulse);
        
    }
    public void HollowPurple()
    {
        GameObject HollowPurpleObject;
        HollowPurpleObject = Instantiate(HollowPurplaPrefab);
        HollowPurpleObject.transform.position = Player.transform.position + PlayerOrientationX.transform.forward + PlayerOrientationY.transform.forward;
        Rigidbody HollowPurpleRigidbody = HollowPurpleObject.GetComponent<Rigidbody>();
        HollowPurpleRigidbody.AddForce(PlayerOrientationX.transform.forward + PlayerOrientationY.transform.forward * 3, ForceMode.Impulse);
    }
}
