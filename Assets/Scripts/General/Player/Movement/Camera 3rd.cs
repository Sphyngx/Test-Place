using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Camera3rd : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Orientation;
    float MouseX;
    float MouseY;
    public float Sensetivity;
    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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

        Orientation.transform.rotation = rotationY * rotationX;
    }
}
