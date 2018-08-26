using System.Collections.Generic;
using UnityEngine;
using WorldGen.GUI;
using WorldGen.PlanetGenerator;

namespace WorldGen
{
    public class Main : MonoBehaviour
    {
        public RectTransform RectTransform;
        
        
        //настройки
        public Material grndMaterial;
        public Material oceanMaterial;
        
        private void Start ()
        {
            PlanetPropt propt = new PlanetPropt();
            propt.R = PlanetData.R_DEF_CONST;
            propt.Seed = PlanetData.SEED_DEF_CONST;
            propt.Size = PlanetData.SIZE_DEF_CONST;
            propt.HMax = PlanetData.HMAX_DEF_CONST;
            propt.HMin = PlanetData.HMIN_DEF_CONST;
            propt.HOcean = PlanetData.HOCEAN_DEF_CONST;
            
            
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