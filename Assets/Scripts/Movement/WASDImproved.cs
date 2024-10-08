using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDImproved : MonoBehaviour
{
    public float MoveSpeed = 0;
    public GameObject OrientationXZ;
    Rigidbody Rigidbody;
    float HorizontalInput;
    float VerticalInput;
    

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Inputs();
        
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Inputs()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }
    void Move()
    {
        Vector3 Forward = OrientationXZ.transform.forward * VerticalInput + OrientationXZ.transform.right * HorizontalInput;
        Rigidbody.AddForce(Forward.normalized * MoveSpeed, ForceMode.Force);
    }
}

