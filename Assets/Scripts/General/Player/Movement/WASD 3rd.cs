using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD3rd : MonoBehaviour
{
    GameObject Player;
    public CharacterController PlayerController;
    public float Speed;
    float HorizontalInput;
    float VerticalInput;
    void Start()
    {
        Player = gameObject;
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
        
        
            PlayerController.SimpleMove(new Vector3(HorizontalInput * Speed, VerticalInput * Speed));
        
    }
}