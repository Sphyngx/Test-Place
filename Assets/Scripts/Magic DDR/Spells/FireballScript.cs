using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireballScript : Spell
{
    Destructionhandler Destructionhandler;
    public LayerMask Movable;
    public LayerMask Damagable;
    public int ExplotionSize = 0;
    private void Start()
    {
        Rigidbody FireBallRigidBody = gameObject.GetComponent<Rigidbody>();
        FireBallRigidBody.AddForce(transform.forward * 5, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Fireball Hit:" + collision);
        Destroy(gameObject);
        //Knockback on Movable Objects
        Collider[] HitMovable = Physics.OverlapSphere(gameObject.transform.position, ExplotionSize, Movable);
        for (int i = 0; i < HitMovable.Length; i++)
        {
            
            HitMovable[i].AddComponent<Rigidbody>();
            Rigidbody ObjectRigidbody = HitMovable[i].GetComponent<Rigidbody>();
            ObjectRigidbody.mass = 2;
            Vector3 Direction = HitMovable[i].gameObject.transform.position - gameObject.transform.position;
            ObjectRigidbody.AddForce(Direction.normalized * 4 + new Vector3(0,2), ForceMode.Impulse);
        }
    }
}
