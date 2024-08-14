using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    Rigidbody RB;
    int Speed = 4;
    int JumpForce = 15;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        void WASD()
        {
            float H = Input.GetAxisRaw("Horizontal");
            float V = Input.GetAxisRaw("Vertical");
            Vector3 Movement = new Vector3(H * Speed, 0, V * Speed);
            RB.velocity = Movement;
        }
        WASD();
        void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB.AddForce(0, JumpForce, 0, (ForceMode.Impulse));
            }
        }
        Jump();
    }
}