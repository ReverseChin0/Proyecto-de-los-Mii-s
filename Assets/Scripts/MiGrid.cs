using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiGrid : MonoBehaviour
{
    [SerializeField]
    [Range(0.9f,10f)]
    private float size = 1f;

    private Vector3 inicialPos = new Vector3(-13.5f,0,-9.0f);
    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);

        result += transform.position;

        return result;
    }

    public List<Vector3> OrdenarAvataresconGrid(List<Avatar> ne, List<Avatar> ro, List<Avatar> ama, List<Avatar> ver)
    {
        List<Vector3> tr= new List<Vector3>();
        float x = inicialPos.x;
        float z = inicialPos.z;

        float tempsize = 1f;

        if (ro != null && ro.Count != 0)
        {
            tempsize = map(tempsize,0, ro.Count, 0.9f, 5.0f);
            //Debug.Log("rojo " + tempsize);
            foreach (Avatar a in ro)
            {
                tr.Add(new Vector3(x,0.0f,z));
                x += tempsize;
                if (x > inicialPos.x + 8)
                {
                    x = inicialPos.x;
                    z += tempsize;
                }
            }
        }
        tempsize = 1f;

        if (ne != null && ne.Count != 0)
        {
            tempsize = map(tempsize, 0, ne.Count, 0.9f, 5.0f);
            //Debug.Log("negro " + tempsize);
            foreach (Avatar a in ne)
            {
                tr.Add(new Vector3(x, 0.0f, z));
                x += tempsize;
                if (x > inicialPos.x + 8)
                {
                    x = inicialPos.x;
                    z += tempsize;
                }
            }
        }
        tempsize = 1f;
        x = inicialPos.x + 10;
        z = inicialPos.z;

        if (ama != null && ama.Count != 0)
        {
            tempsize = map(tempsize, 0, ama.Count, 0.9f, 5.0f);
            //Debug.Log("ama " + tempsize);
            foreach (Avatar a in ama)
            {
                tr.Add(new Vector3(x, 0.0f, z));
                x += tempsize;
                if (x > inicialPos.x + 18)
                {
                    x = inicialPos.x + 10;
                    z += tempsize;
                }
            }
        }
        tempsize = 1f;
        x = inicialPos.x + 20;
        z = inicialPos.z;

        if (ver != null && ver.Count != 0)
        {
            tempsize = map(tempsize, 0, ver.Count, 0.9f, 5.0f);
            //Debug.Log("ver " + tempsize);
            foreach (Avatar a in ver)
            {
                tr.Add(new Vector3(x, 0.0f, z));
                x += tempsize;
                if (x > inicialPos.x + 28)
                {
                    x = inicialPos.x + 20;
                    z += tempsize;
                }
            }
        }

        return tr;
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (float x = inicialPos.x; x < inicialPos.x + 8; x += size)
        {
            for (float z = inicialPos.z; z < inicialPos.z + 16; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }

        }

        Gizmos.color = Color.yellow;
        for (float x = inicialPos.x + 10; x < inicialPos.x + 18; x += size)
        {
            for (float z = inicialPos.z; z < inicialPos.z + 16; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }

        }

        Gizmos.color = Color.green;
        for (float x = inicialPos.x + 20; x < inicialPos.x + 28; x += size)
        {
            for (float z = inicialPos.z; z < inicialPos.z + 16; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }*/

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

}
