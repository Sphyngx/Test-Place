using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Health")]
    public float HP;
    public float MaxHP;
    public float HPRegenMultiplier;
    [Header("Mana")]
    public float MP;
    public float MaxMP;
    public float MPRegenMultiplier;

    [NonSerialized] public Spell SpellUsed;

    [NonSerialized] public GameObject Camera;
    GameObject PlayerModel;
    [NonSerialized] public GameObject Orientation;
    [NonSerialized] public Transform OrientationY;
    private void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("Camera");
        PlayerModel = GameObject.FindGameObjectWithTag("PlayerModel");
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            if (child.name.Contains("Orientation"))
            {
                Orientation = child.gameObject;
            }
        }

        if(Orientation == null)
        {
            Debug.LogWarning("No orientation on player :(");
        }
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (SpellUsed != null && !SpellUsed.ManaDrain)
        {
            if (MP >= SpellUsed.ManaCost)
            {
                MP -= SpellUsed.ManaCost;
                SpellUsed = null;
            }
            else
            {
                SpellUsed = null;
                Debug.Log("Not enough mana");
            }
        }
        else if (SpellUsed != null && SpellUsed.ManaDrain)
        {
            if (MP >= Time.deltaTime * SpellUsed.ManaDrainMultiplier && SpellUsed.gameObject != null)
            {
                Debug.Log("drain test: " + SpellUsed.gameObject);
                MP -= Time.deltaTime * SpellUsed.ManaDrainMultiplier;
            }
            else
            {
                SpellUsed = null;
                Debug.Log("Not enough mana");
            }
        }
        Orientation.transform.forward = Camera.transform.forward;
        OrientationY = Orientation.transform;
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
    private void FixedUpdate()
    {
        if (MP < MaxMP)
        {
            MP += Time.deltaTime * MPRegenMultiplier;
        }
    }
}