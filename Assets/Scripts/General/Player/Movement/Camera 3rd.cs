using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Camera3rd : MonoBehaviour
{
    public GameObject Camera;
    public GameObject CameraPos;
    public GameObject OrientationX;
    public GameObject OrientationY;
    Vector3 DefaultPos = new Vector3(1.5f, 1.2f, -4);
    float MouseX;
    float MouseY;
    public float Sensetivity;
    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CameraPos.transform.position = DefaultPos;
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

        
        OrientationY.transform.localRotation = rotationY; 
        OrientationX.transform.localRotation = rotationX;  
    }
}
