using System;
using System.Collections.Generic;
using UnityEngine;
using WorldGen.Utils;

namespace WorldGen.PlanetGenerator
{
    public class PlanetGameObject
    {
        
        
        private PlanetController _controller;

        public PlanetGameObject(PlanetController controller)
        {
            _controller = controller;
        }

        private PlanetPropt Propt
        {
            get { return _controller.planetPropt; }
        }

        private PlanetData Data
        {
            get { return _controller.Data; }
        }
        
        
        
        public GameObject ground;
        public GameObject ocean;
        
        public void GenerateGameObject()
        {
            if (ground != null)
                PlanetController.Instance.Parent.DestroyObj(ground);
            
            ground = new GameObject();
            ground.transform.SetParent(_controller.Parent.gameObject.transform);
            
            var grndMesh = new Mesh();
            grndMesh.vertices = GrndVerticles();
            grndMesh.triangles = Triangles();
            addMeshToGO(ground, grndMesh, _controller.Parent.grndMaterial);//TODO убрать присвоение материала таким образом
            
            
            
            if (ocean != null)
                PlanetController.Instance.Parent.DestroyObj(ocean);
            
            ocean = new GameObject();
            ocean.transform.SetParent(_controller.Parent.gameObject.transform);
            
            var oceanMesh = new Mesh();
            oceanMesh.vertices = OceanVerticles();
            oceanMesh.triangles = Triangles();
            addMeshToGO(ocean, oceanMesh, _controller.Parent.oceanMaterial);//TODO убрать присвоение материала таким образом
            ocean.transform.position += Vector3.forward;
        }

        private void addMeshToGO(GameObject gameObject, Mesh mesh, Material material)
        {
            gameObject.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = new MeshRenderer();
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshRenderer.material = material;
            gameObject.GetComponent<MeshFilter>().mesh = mesh;
        }

        private Vector3[] GrndVerticles()
        {
            List<Vector3> vertices = new List<Vector3>();
            vertices.Add(Vector3.zero);
            int n = Data.Ground.Length;
            float koef = Convert.ToSingle(Math.PI*2/n);
            for (int i = 0; i < n; i++)
            {
                vertices.Add(CSConverter.ToCartesian(Data.Ground[i], i*koef));
            }
            return vertices.ToArray();
        }

        private Vector3[] OceanVerticles()
        {
            List<Vector3> vertices = new List<Vector3>();
            vertices.Add(Vector3.zero);
            int n = Data.Ground.Length;
            float koef = Convert.ToSingle(Math.PI*2/n);
            for (int i = 0; i < n; i++)
            {
                vertices.Add(CSConverter.ToCartesian(Propt.HOcean, i*koef));
            }
            return vertices.ToArray();
        }

        private int[] Triangles()
        {
            int n = Data.Ground.Length;
            List<int> triangles = new List<int>();
            for (int i = 1; i < n-1; i++)
            {
                triangles.Add(0);
                triangles.Add(i+1);
                triangles.Add(i);
            }
            
            triangles.Add(0);
            triangles.Add(1);
            triangles.Add(n-1);

            return triangles.ToArray();
        }
    }
}