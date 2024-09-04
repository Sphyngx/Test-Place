using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    InputHandler InputHandler;
    public GameObject Player;
    public GameObject PlayerOrientationXZ;
    public GameObject PlayerOrientationY;
    [Header("Flare")]
    public GameObject FlarePrefab;
    public GameObject FlareObject;
    public GameObject FlarePos;
    [Header("Fireball")]
    public GameObject FireballPrefab;
    private void Start()
    {
        InputHandler = GetComponent<InputHandler>();
    }
    public void Flare()
    {
        FlareObject = Instantiate(FlarePrefab);
        FlareObject.transform.position = FlarePos.transform.position;
        InputHandler.FinishCast = false;
    }
    public void Fireball()
    {
        GameObject FireballObject;
        FireballObject = Instantiate(FireballPrefab);
        Rigidbody FireballRigidbody = FireballObject.GetComponent<Rigidbody>();
        FireballObject.transform.position = Player.transform.position + PlayerOrientationXZ.transform.forward + PlayerOrientationY.transform.forward;
        FireballRigidbody.AddForce(PlayerOrientationXZ.transform.forward * 5,ForceMode.Impulse);
        FireballRigidbody.AddForce(PlayerOrientationY.transform.forward * 5, ForceMode.Impulse);
        InputHandler.FinishCast = false;
    }
}
