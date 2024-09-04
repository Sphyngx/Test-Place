using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    InputHandler InputHandler;
    public UnityEngine.UI.Image image = null;
    public Sprite[] Runes = null;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            image.sprite = Runes[8];
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            image.sprite = Runes[6];
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            image.sprite = Runes[9];
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            image.sprite = Runes[4];
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            image.sprite = Runes[7];
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            image.sprite = Runes[5];
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            image.sprite = Runes[0];
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            image.sprite = Runes[3];
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            image.sprite = Runes[2];
        }
    }
}
