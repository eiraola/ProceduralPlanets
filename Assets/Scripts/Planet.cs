using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(2,256)]
    public int resolution = 10;

    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    TerrainFace[] terrainFaces;
    // Start is called before the first frame update
    private void OnValidate()
    {
        Initialize();
        GeneratMesh();
    }
    void Initialize() {

        if (meshFilters == null || meshFilters.Length == 0) { 

             meshFilters = new MeshFilter[6];
        }
        terrainFaces = new TerrainFace[6];
        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i]==null){

            GameObject meshObj = new GameObject("mesh");
            meshObj.transform.parent = transform;
            
            meshObj.AddComponent<MeshRenderer>().sharedMaterial=new Material(Shader.Find("Standard"));
            meshFilters[i] = meshObj.AddComponent<MeshFilter>();
            meshFilters[i].sharedMesh = new Mesh();

            }
            terrainFaces[i]= new TerrainFace(meshFilters[i].sharedMesh,resolution,directions[i]);
        }
    }

    void GeneratMesh() {
        foreach (TerrainFace face in  terrainFaces)
        {
            face.ConstructMesh();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
