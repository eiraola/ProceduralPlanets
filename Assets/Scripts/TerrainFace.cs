using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFace : MonoBehaviour
{
    // Start is called before the first frame update
    Mesh mesh;
    int resolution;
    Vector3 localUp;
    Vector3 axisA;
    Vector3 axisB;
    void Start()
    {
        
    }
    public TerrainFace(Mesh mesh, int resolution, Vector3 localUp) 
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.localUp = localUp;

        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);

    }

    public void ConstructMesh() {

        int trIndex = 0;
        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution -1)*(resolution -1)*6];
        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                int i = x + y * resolution;
                Vector2 percent = new Vector2(x,y)/(resolution-1);
                Vector3 pointOnCube=localUp + (percent.x -0.5f)*2*axisA + (percent.y-0.5f)*2 *axisB;
                Vector3 pointSphere = pointOnCube.normalized; 
                vertices[i] = pointSphere;

                if ((x!=resolution-1) && (y!=resolution-1))
                {
                    triangles[trIndex] = i;
                    triangles[trIndex + 1] = i + resolution + 1;
                    triangles[trIndex + 2] = resolution + i;

                    triangles[trIndex + 3] = i;
                    triangles[trIndex + 4] = i  + 1;
                    triangles[trIndex + 5] = resolution + i +1;

                    trIndex += 6;
                }
            }

        }
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
