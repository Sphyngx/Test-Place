using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class VisionAI : MonoBehaviour
{
    public bool SeeingPlayer;
    public GameObject PlayerBody;
    [Header("Sensor")]
    public float SensDistance = 0f;
    public float SensAngle = 0f;
    public float SensHeight = 0f;
    public Color SensColor = Color.red;
    public int ScanFrequency = 0;
    [Header("Sensor Layers")]
    public LayerMask Layers;
    public LayerMask OcclusionLayer;
    public List<GameObject> Objects = new List<GameObject>();

    Collider[] Colliders = new Collider[50];
    Mesh SensMesh;
    int Count;
    float ScanInterval;
    float ScanTimer;
    private void Start()
    {
        ScanInterval = 1f / ScanFrequency;
    }
    private void Update()
    {
        ScanTimer -= Time.deltaTime;
        if (ScanTimer < 0)
        {
            ScanTimer += ScanInterval;
            Scan();
        }
        if (Objects.Contains(PlayerBody))
        {
            SeeingPlayer = true;
        }
        else
        {
            SeeingPlayer = false;
        }
    }
    private void Scan()
    {
        Count = Physics.OverlapSphereNonAlloc(transform.position, SensDistance,Colliders, Layers,QueryTriggerInteraction.Collide);

        Objects.Clear();
        for (int i = 0;i < Count; i++)
        {
            GameObject Obj = Colliders[i].gameObject;
            if (IsInsight(Obj))
            {
                Objects.Add(Obj);
            }
        }
    }
    public bool IsInsight(GameObject Obj)
    {
        Vector3 Origin = transform.position;
        Vector3 Destination = Obj.transform.position;
        Vector3 Direction = Destination - Origin;
        if (Direction.y < 0 - SensHeight / 2 || Direction.y > SensHeight)
        {
            return false;
        }
        Direction.y = 0;
        float DeltaAngle = Vector3.Angle(Direction, transform.forward);
        if (DeltaAngle > SensAngle)
        {
            return false;
        }
        Origin.y += SensHeight / 2;
        Destination.y = Origin.y;
        if (Physics.Linecast(Origin, Destination,OcclusionLayer)) 
        {
            return false;
        }
        return true;
    }
    Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();
        int Segments = 10;
        int NumTriangles = (Segments * 4)+2+2;
        int NumVertices = NumTriangles * 3;
        Vector3[] Vertices = new Vector3[NumVertices];
        int[] Triangles = new int[NumVertices];
        Vector3 BottomCenter = Vector3.zero - new Vector3(0,SensHeight/2,0);
        Vector3 BottomLeft = Quaternion.Euler(0, -SensAngle, 0) * Vector3.forward * SensDistance - new Vector3(0,SensHeight/2,0);
        Vector3 BottomRight = Quaternion.Euler(0, SensAngle, 0) * Vector3.forward * SensDistance - new Vector3(0, SensHeight/2, 0);
        Vector3 TopCenter = BottomCenter + Vector3.up * SensHeight;
        Vector3 TopLeft = BottomLeft + Vector3.up * SensHeight;
        Vector3 TopRight = BottomRight + Vector3.up * SensHeight;
        int Vert = 0;
        //left side
        Vertices[Vert++] = BottomCenter;
        Vertices[Vert++] = BottomLeft;
        Vertices[Vert++] = TopLeft;
        
        Vertices[Vert++] = TopLeft;
        Vertices[Vert++] = TopCenter;
        Vertices[Vert++] = BottomCenter;
        //right side
        Vertices[Vert++] = BottomCenter;
        Vertices[Vert++] = TopCenter;
        Vertices[Vert++] = TopRight;

        Vertices[Vert++] = TopRight;
        Vertices[Vert++] = BottomRight;
        Vertices[Vert++] = BottomCenter;

        float CurrentAngle = -SensAngle;
        float DeltaAngle = (SensAngle * 2) / Segments;
        for (int i = 0; i < Segments; i++)
        {
            BottomLeft = Quaternion.Euler(0, CurrentAngle, 0) * Vector3.forward * SensDistance - new Vector3(0,SensHeight/2,0);
            BottomRight = Quaternion.Euler(0, CurrentAngle + DeltaAngle, 0) * Vector3.forward * SensDistance - new Vector3(0,SensHeight/2,0);
            
            TopLeft = BottomLeft + Vector3.up * SensHeight;
            TopRight = BottomRight + Vector3.up * SensHeight;

            //far side
            Vertices[Vert++] = BottomLeft;
            Vertices[Vert++] = BottomRight;
            Vertices[Vert++] = TopRight;

            Vertices[Vert++] = TopRight;
            Vertices[Vert++] = TopLeft;
            Vertices[Vert++] = BottomLeft;
            //top
            Vertices[Vert++] = TopCenter;
            Vertices[Vert++] = TopLeft;
            Vertices[Vert++] = TopRight;
            //bottom
            Vertices[Vert++] = BottomCenter;
            Vertices[Vert++] = BottomRight;
            Vertices[Vert++] = BottomLeft;

            CurrentAngle += DeltaAngle;
        }
        for (int i = 0;i < NumVertices; i++)
        {
            Triangles[i] = i;
        }
        mesh.vertices = Vertices;
        mesh.triangles = Triangles;
        mesh.RecalculateNormals();
        return mesh;
    }
    private void OnValidate()
    {
        SensMesh = CreateWedgeMesh();
    }
    private void OnDrawGizmos()
    {
        if (SensMesh)
        {
            Gizmos.color = SensColor;
            Gizmos.DrawMesh(SensMesh, transform.position, transform.rotation);
        }
        Gizmos.DrawWireSphere(transform.position, SensDistance);
        for (int i = 0;i < Count;i++)
        {
            Gizmos.DrawSphere(Colliders[i].transform.position, 0.2f);
        }
        Gizmos.color = Color.green;
        foreach (var Obj in Objects)
        {
            Gizmos.DrawSphere(Obj.transform.position, 0.2f);
        }
    }
}

