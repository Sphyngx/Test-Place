using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Camera3rd camera3rd;
    GameObject Player;
    Rigidbody PlayerRigidbody;
    public GameObject PlayerModel;
    
    public float MaxSpeed;
    private void Start()
    {
        Player = gameObject;
        PlayerRigidbody = GetComponent<Rigidbody>();
        camera3rd = FindObjectOfType<Camera3rd>();
    }
    void Update()
    {
        //Make the playermodel face the correct orientation
        PlayerModel.transform.rotation = camera3rd.OrientationY.transform.rotation * Quaternion.Euler(0,180,0) * Quaternion.Euler(-90,0,0);

        //Cap the Max speed
        Vector3 velocity = PlayerRigidbody.velocity;

        if (Mathf.Abs(velocity.x) > MaxSpeed)
        {
            velocity.x = MaxSpeed * Mathf.Sign(velocity.x);
        }
        if (Mathf.Abs(velocity.y) > MaxSpeed)
        {

            velocity.y = MaxSpeed * Mathf.Sign(velocity.y);
        }
        if (Mathf.Abs(velocity.z) > MaxSpeed)
        {

            velocity.z = MaxSpeed * Mathf.Sign(velocity.z);
        }
        PlayerRigidbody.velocity = velocity;
    }
}
