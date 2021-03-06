﻿namespace Pathfinding
{
    using System;
    using UnityEngine;

    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_debug_utility.php")]
    public class DebugUtility : MonoBehaviour
    {
        public static DebugUtility active;
        public Material defaultMaterial;
        public float offset = 0.2f;
        public bool optimizeMeshes;

        public void Awake()
        {
            active = this;
        }

        public static void DrawCubes(Vector3[] topVerts, Vector3[] bottomVerts, Color[] vertexColors, float width)
        {
            if (active == null)
            {
                active = UnityEngine.Object.FindObjectOfType(typeof(DebugUtility)) as DebugUtility;
            }
            if (active == null)
            {
                throw new NullReferenceException();
            }
            if ((topVerts.Length != bottomVerts.Length) || (topVerts.Length != vertexColors.Length))
            {
                Debug.LogError("Array Lengths are not the same");
            }
            else
            {
                if (topVerts.Length > 0xa94)
                {
                    Vector3[] vectorArray = new Vector3[topVerts.Length - 0xa94];
                    Vector3[] vectorArray2 = new Vector3[topVerts.Length - 0xa94];
                    Color[] colorArray = new Color[topVerts.Length - 0xa94];
                    for (int j = 0xa94; j < topVerts.Length; j++)
                    {
                        vectorArray[j - 0xa94] = topVerts[j];
                        vectorArray2[j - 0xa94] = bottomVerts[j];
                        colorArray[j - 0xa94] = vertexColors[j];
                    }
                    Vector3[] vectorArray3 = new Vector3[0xa94];
                    Vector3[] vectorArray4 = new Vector3[0xa94];
                    Color[] colorArray2 = new Color[0xa94];
                    for (int k = 0; k < 0xa94; k++)
                    {
                        vectorArray3[k] = topVerts[k];
                        vectorArray4[k] = bottomVerts[k];
                        colorArray2[k] = vertexColors[k];
                    }
                    DrawCubes(vectorArray, vectorArray2, colorArray, width);
                    topVerts = vectorArray3;
                    bottomVerts = vectorArray4;
                    vertexColors = colorArray2;
                }
                width /= 2f;
                Vector3[] vectorArray5 = new Vector3[(topVerts.Length * 4) * 6];
                int[] numArray = new int[(topVerts.Length * 6) * 6];
                Color[] colorArray3 = new Color[(topVerts.Length * 4) * 6];
                for (int i = 0; i < topVerts.Length; i++)
                {
                    Vector3 vector = topVerts[i] + new Vector3(0f, active.offset, 0f);
                    Vector3 vector2 = bottomVerts[i] - new Vector3(0f, active.offset, 0f);
                    Vector3 vector3 = vector + new Vector3(-width, 0f, -width);
                    Vector3 vector4 = vector + new Vector3(width, 0f, -width);
                    Vector3 vector5 = vector + new Vector3(width, 0f, width);
                    Vector3 vector6 = vector + new Vector3(-width, 0f, width);
                    Vector3 vector7 = vector2 + new Vector3(-width, 0f, -width);
                    Vector3 vector8 = vector2 + new Vector3(width, 0f, -width);
                    Vector3 vector9 = vector2 + new Vector3(width, 0f, width);
                    Vector3 vector10 = vector2 + new Vector3(-width, 0f, width);
                    int index = (i * 4) * 6;
                    int num5 = (i * 6) * 6;
                    Color color = vertexColors[i];
                    for (int m = index; m < (index + 0x18); m++)
                    {
                        colorArray3[m] = color;
                    }
                    vectorArray5[index] = vector3;
                    vectorArray5[index + 1] = vector6;
                    vectorArray5[index + 2] = vector5;
                    vectorArray5[index + 3] = vector4;
                    index += 4;
                    vectorArray5[index + 3] = vector7;
                    vectorArray5[index + 2] = vector10;
                    vectorArray5[index + 1] = vector9;
                    vectorArray5[index] = vector8;
                    index += 4;
                    vectorArray5[index] = vector8;
                    vectorArray5[index + 1] = vector4;
                    vectorArray5[index + 2] = vector5;
                    vectorArray5[index + 3] = vector9;
                    index += 4;
                    vectorArray5[index + 3] = vector7;
                    vectorArray5[index + 2] = vector3;
                    vectorArray5[index + 1] = vector6;
                    vectorArray5[index] = vector10;
                    index += 4;
                    vectorArray5[index + 3] = vector9;
                    vectorArray5[index + 2] = vector10;
                    vectorArray5[index + 1] = vector6;
                    vectorArray5[index] = vector5;
                    index += 4;
                    vectorArray5[index] = vector8;
                    vectorArray5[index + 1] = vector7;
                    vectorArray5[index + 2] = vector3;
                    vectorArray5[index + 3] = vector4;
                    for (int n = 0; n < 6; n++)
                    {
                        int num8 = index + (n * 4);
                        int num9 = num5 + (n * 6);
                        numArray[num9] = num8;
                        numArray[num9 + 1] = num8 + 1;
                        numArray[num9 + 2] = num8 + 2;
                        numArray[num9 + 3] = num8;
                        numArray[num9 + 4] = num8 + 2;
                        numArray[num9 + 5] = num8 + 3;
                    }
                }
                Mesh mesh = new Mesh();
                mesh.vertices = vectorArray5;
                mesh.triangles = numArray;
                mesh.colors = colorArray3;
                mesh.name = "VoxelMesh";
                mesh.RecalculateNormals();
                mesh.RecalculateBounds();
                if (active.optimizeMeshes)
                {
                    mesh.Optimize();
                }
                GameObject obj2 = new GameObject("DebugMesh");
                MeshRenderer renderer = obj2.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
                renderer.material = active.defaultMaterial;
                (obj2.AddComponent(typeof(MeshFilter)) as MeshFilter).mesh = mesh;
            }
        }

        public static void DrawQuads(Vector3[] verts, float width)
        {
            if (verts.Length >= 0x3f7a)
            {
                Vector3[] vectorArray = new Vector3[verts.Length - 0x3f7a];
                for (int j = 0x3f7a; j < verts.Length; j++)
                {
                    vectorArray[j - 0x3f7a] = verts[j];
                }
                Vector3[] vectorArray2 = new Vector3[0x3f7a];
                for (int k = 0; k < 0x3f7a; k++)
                {
                    vectorArray2[k] = verts[k];
                }
                DrawQuads(vectorArray, width);
                verts = vectorArray2;
            }
            width /= 2f;
            Vector3[] vectorArray3 = new Vector3[verts.Length * 4];
            int[] numArray = new int[verts.Length * 6];
            for (int i = 0; i < verts.Length; i++)
            {
                Vector3 vector = verts[i];
                int index = i * 4;
                vectorArray3[index] = vector + new Vector3(-width, 0f, -width);
                vectorArray3[index + 1] = vector + new Vector3(-width, 0f, width);
                vectorArray3[index + 2] = vector + new Vector3(width, 0f, width);
                vectorArray3[index + 3] = vector + new Vector3(width, 0f, -width);
                int num5 = i * 6;
                numArray[num5] = index;
                numArray[num5 + 1] = index + 1;
                numArray[num5 + 2] = index + 2;
                numArray[num5 + 3] = index;
                numArray[num5 + 4] = index + 2;
                numArray[num5 + 5] = index + 3;
            }
            Mesh mesh = new Mesh();
            mesh.vertices = vectorArray3;
            mesh.triangles = numArray;
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
            GameObject obj2 = new GameObject("DebugMesh");
            MeshRenderer renderer = obj2.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
            renderer.material = active.defaultMaterial;
            (obj2.AddComponent(typeof(MeshFilter)) as MeshFilter).mesh = mesh;
        }
    }
}

