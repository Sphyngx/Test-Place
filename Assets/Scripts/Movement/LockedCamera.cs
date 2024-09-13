using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class LockedCamera : MonoBehaviour
{
    public GameObject View = null;
    public GameObject Head = null; 
    public bool MouseLock = true;
    int Sensetivity = 100;
    float MouseX = 0;
    float MouseY = 0;
    public GameObject OrientationXY = null;
    void Update()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        View.transform.position = Head.transform.position;
        MouseX += Input.GetAxisRaw("Mouse X") * Time.deltaTime * Sensetivity;
        MouseY -= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Sensetivity;
        MouseY = Mathf.Clamp(MouseY, -90f, 90f);
        CameraRot();
    }
    void CameraRot()
    {
        transform.rotation = Quaternion.Euler(MouseY, MouseX, 0);
        OrientationXY.transform.rotation = Quaternion.Euler(MouseY, MouseX, 0);
    }
}
