using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlatform : MonoBehaviour
{
    MoveObject moveObject;
    Mesh mesh;
    MeshRenderer meshRenderer;
    [SerializeField] private Material colorMesh;

    void Start()
    {
        moveObject = GetComponent<MoveObject>();
    }

    public void Metod()
    {
        moveObject.Pause();
        PlatformNew();
        Destroy(gameObject);
    }

    public void PlatformNew()
    {
        GameObject newPlatform = gameObject;
        GameObject obj =  Instantiate(newPlatform, transform.position, Quaternion.identity);

        mesh = new Mesh();
        obj.GetComponent<MeshFilter>().mesh = mesh;
        obj.GetComponent<MoveObject>().enabled = false;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = colorMesh;

        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTriangles();
        mesh.RecalculateNormals();
    }

    Vector3[] GenerateVertices()
    {
        return new Vector3[]
        {

            new Vector3(0.0f, 0.0f, 0.0f),//0
            new Vector3(0.0f, 0.0f, 3.0f),//1
            new Vector3(5.0f, 0.0f, 0.0f),//2
            new Vector3(5.0f, 0.0f, 3.0f),//3

            new Vector3(0.0f, -1.0f, 0.0f),//4
            new Vector3(0.0f, -1.0f, 3.0f),//5
            new Vector3(5.0f, -1.0f, 0.0f),//6
            new Vector3(5.0f, -1.0f, 3.0f),//7
        };
    }
    int[] GenerateTriangles()
    {
        return new int[]
        {
            0, 1, 2,
            1, 3, 2,
            4, 5, 0,
            5, 1, 0,
            4, 0, 6,
            0, 2, 6,
            2, 3, 6,
            3, 7, 6,
            3, 1, 7,
            1, 5, 7,
            7, 5, 6,
            5, 4, 6
        };
    }
}
