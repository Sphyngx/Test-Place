using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    [Header("Tarrot GameObject")]
    public GameObject View;
    public GameObject Orientation;
    public GameObject Player;
    public GameObject TarrotM;
    private void Update()
    {
        Vector3 offset = Orientation.transform.forward;
        Vector3 TarrotMPos = Orientation.transform.position + offset;
        TarrotM.transform.position = TarrotMPos;
        Quaternion downwardRotation = Quaternion.Euler(60, 0, 0);
        TarrotM.transform.rotation = Orientation.transform.rotation * downwardRotation;
        if (Input.GetKeyDown(KeyCode.E))
        {   
            TarrotMenu();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            TarrotMenuClose();
        }
    }
    void TarrotMenu()
    {
        View.GetComponent<LockedCamera>().enabled = false;
        View.transform.position = TarrotM.transform.position;
        View.transform.rotation = TarrotM.transform.rotation;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }
    private void TarrotMenuClose()
    {
        View.GetComponent<LockedCamera>().enabled = true;
        
    }
}

