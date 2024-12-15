using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject Player;
    public GameObject Camera;
    public GameObject PlayerModel;
    public GameObject Orientation;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Player = gameObject;
    }
    void Update()
    {

        Orientation.transform.forward = Camera.transform.forward;
        Transform OrientationY = Orientation.transform;
        OrientationY.eulerAngles = new Vector3
        (
        0,
        Orientation.transform.eulerAngles.y,
        OrientationY.eulerAngles.z
        );

        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");
        Vector3 PlayerViewDirection = OrientationY.transform.forward * VerticalInput + OrientationY.transform.right * HorizontalInput;

        if (PlayerViewDirection != Vector3.zero)
        {
            Quaternion TargetRotation = Quaternion.LookRotation(PlayerViewDirection);
            TargetRotation *= Quaternion.Euler(-90, 180, 0);
            PlayerModel.transform.rotation = Quaternion.Slerp(PlayerModel.transform.rotation, TargetRotation, Time.deltaTime * 10);
        }
    }
}
