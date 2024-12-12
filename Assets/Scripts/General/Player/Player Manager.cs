using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject Player;
    Rigidbody PlayerRigidbody;
    public GameObject PlayerModel;
    public GameObject Orientation;
    float MouseX;
    float MouseY;
    public float Sensetivity;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Player = gameObject;
        PlayerRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float mouseInputX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * Sensetivity;
        float mouseInputY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Sensetivity;

        MouseY += mouseInputX;
        MouseX -= mouseInputY;
        MouseX = Mathf.Clamp(MouseX, -70f, 75f);

        Quaternion rotationX = Quaternion.Euler(MouseX, 0, 0);
        Quaternion rotationY = Quaternion.Euler(0, MouseY, 0);

        //Orientation.transform.rotation = rotationY * rotationX;

        //Make the playermodel face the correct orientation
    }
}
