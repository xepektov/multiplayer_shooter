using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer_collider_script : MonoBehaviour
{
    LineRenderer Line;

    // Start is called before the first frame update
    void Start()
    {
        Line = this.GetComponent<LineRenderer>();
        GenerateMeshCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMeshCollider()
    {
        MeshCollider collider = GetComponent<MeshCollider>();

        //Line.useWorldSpace = false; //

        if (collider == null)
        {
            collider = gameObject.AddComponent<MeshCollider>();
        }


        Mesh mesh = new Mesh();
        Line.BakeMesh(mesh, Camera.main, true); //

        // if you need collisions on both sides of the line, simply duplicate & flip facing the other direction!
        // This can be optimized to improve performance ;)
        /*int[] meshIndices = mesh.GetIndices(0);
        int[] newIndices = new int[meshIndices.Length * 2];

        int j = meshIndices.Length - 1;
        for (int i = 0; i < meshIndices.Length; i++)
        {
            newIndices[i] = meshIndices[i];
            newIndices[meshIndices.Length + i] = meshIndices[j];
        }
        mesh.SetIndices(newIndices, MeshTopology.Triangles, 0);*/

        collider.sharedMesh = mesh;
    }
}
