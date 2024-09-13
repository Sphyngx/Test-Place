using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowPurpleHandler : MonoBehaviour
{
    public int Size;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        GameObject Object = other.GetComponent<GameObject>();
        Destroy(Object);
    }
}
