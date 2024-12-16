using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD3rd : MonoBehaviour
{
    public PlayerManager PlayerManager;
    GameObject Player;
    public CharacterController PlayerController;
    public float Speed;
    float HorizontalInput;
    float VerticalInput;
    void Start()
    {
        Player = gameObject;
        PlayerManager = Player.GetComponent<PlayerManager>();
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
        Vector3 MoveDirection = PlayerManager.OrientationY.forward * VerticalInput + PlayerManager.OrientationY.right * HorizontalInput;
        PlayerController.SimpleMove(new Vector3(MoveDirection.normalized.x * Speed, 0 , MoveDirection.normalized.z * Speed));
    }
}