using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    GameObject CubeGen;
    public GameObject Testcube;
    int X;
    int Y;
    int Z;
    void Start()
    {
        Cube BaseCube = new Cube();
        CubeGen = GameObject.FindGameObjectWithTag("CubeGen");
    }

    void Update()
    {
        for (;X < CubeGen.transform.localScale.x;X++)
        {
            Debug.Log("this is X:" + X);
            if (CubeGen.transform.localScale.x % 1 == 0)
            {
                Instantiate<GameObject>(Testcube, new Vector3(X, 0, 0), new Quaternion(0, 0, 0, 0));
            }
            else
            {
                break;
            }
        }
        for (;Y < CubeGen.transform.localScale.y; Y++)
        {
            Debug.Log("this is Y:" + Y);
            if (CubeGen.transform.localScale.y % 1 == 0)
            {
                
                Instantiate<GameObject>(Testcube, new Vector3(0, Y, 0), new Quaternion(0, 0, 0, 0));
            }
            else
            {
                break;
            }
        }
        for (;Z < CubeGen.transform.localScale.z; Z++)
        {
            Debug.Log("this is Z:" + Z);
            if (CubeGen.transform.localScale.z % 1 == 0)
            {
                Instantiate<GameObject>(Testcube, new Vector3(0, 0, Z), new Quaternion(0, 0, 0, 0));
            }
            else
            {
                break;
            }
        }




    }
}
