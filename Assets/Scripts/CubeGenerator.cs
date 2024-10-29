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

        SpawnCubes();
    }

    void SpawnCubes()
    {
        for (int ix = 0; ix < CubeGen.transform.localScale.x; ix++)
        {
            for (int iy = 0; iy < CubeGen.transform.localScale.y; iy++)
            {
                for (int iz = 0; iz < CubeGen.transform.localScale.z; iz++)
                {
                    if (CubeGen.transform.localScale.y % 1 == 0)
                    {

                        Instantiate<GameObject>(Testcube, new Vector3(ix, iy, iz), new Quaternion(0, 0, 0, 0));
                    }
                }
                
            }
        }
    }

    void Update()
    {
        

        if(X != (int)CubeGen.transform.localScale.x)
        {
            X = (int)CubeGen.transform.localScale.x;
        }
        if(Y != (int)CubeGen.transform.localScale.y)
        {
            Y = (int)CubeGen.transform.localScale.y;
        }
        
    }
    void VectorXZ(Vector3 StartCollumn)
    {
        Instantiate<GameObject>(Testcube, StartCollumn, new Quaternion(0, 0, 0, 0));
        
    }
}
