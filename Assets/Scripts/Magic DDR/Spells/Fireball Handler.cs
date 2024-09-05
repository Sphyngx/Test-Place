using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHandler : MonoBehaviour
{
    public LayerMask Movable;
    public LayerMask Damagable;
    public int ExplotionSize = 0;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        //Knockback on Movable Objects
        Collider[] HitMovable = Physics.OverlapSphere(gameObject.transform.position, ExplotionSize, Movable);
        for (int i = 0; i < HitMovable.Length; i++)
        {
            Rigidbody ObjectRigidbody = HitMovable[i].GetComponent<Rigidbody>();
            GameObject Object = HitMovable[i].GetComponent<GameObject>();
            Vector3 Direction = HitMovable[i].gameObject.transform.position - gameObject.transform.position;
            ObjectRigidbody.AddForce(Direction.normalized * 4 + new Vector3(0,2), ForceMode.Impulse);
        }
    }
}
