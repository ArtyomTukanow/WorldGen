using System.Collections.Generic;
using UnityEngine;
using WorldGen.GUI;

namespace WorldGen
{
    public class Main : MonoBehaviour
    {
        public RectTransform RectTransform;
        
        
        //настройки
        public Material grndMaterial;
        public Material oceanMaterial;
        public int size = 4;
        public int seed = 0;
        public float r = 0.1F;
        public float xMin = 1;
        public float xMax = 5;
        public float xOcean = 3;
        
        private void Start ()
        {
            PlanetPropt propt = new PlanetPropt();
            propt.R = r/(xMax-xMin);
            propt.Seed = seed;
            propt.Size = size;
            propt.xMax = xMax;
            propt.xMin = xMin;
            propt.xOcean = xOcean;
            
            
            
            PlanetController.Instance.Parent = this;
            PlanetController.Instance.GenerateNewPlanet(propt);
            GUIManager.CreateGUI(RectTransform);
        }

        public static void SendMessage(string mess)
        {
            print(mess);
        }

        public void DestroyObj(Object obj)
        {
            Destroy(obj);
        }
    }
}