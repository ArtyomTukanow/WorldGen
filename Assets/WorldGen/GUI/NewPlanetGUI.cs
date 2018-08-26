using System;
using UnityEngine;
using UnityEngine.UI;

namespace WorldGen.GUI
{
    public class NewPlanetGUI
    {
        
        //GUI
        private GameObject GUILayer;
        public GameObject GUIBackground;
        public Scrollbar Size;
        public Scrollbar Seed;
        public Scrollbar R;
        public Scrollbar hMin;
        public Scrollbar hMax;
        public Scrollbar hOcean;
        
        public Text SizeText;
        public Text SeedText;
        public Text RText;
        public Text HMinText;
        public Text HMaxText;
        public Text HOceanText;
        
        public NewPlanetGUI(Transform parent)
        {
            GUILayer = GameObject.Find("NewPlanetLayer");
            GUIBackground = GUILayer.transform.FindChild("Background").gameObject;
            Size = GUIBackground.transform.FindChild("Size").GetComponent<Scrollbar>();
            Seed = GUIBackground.transform.FindChild("Seed").GetComponent<Scrollbar>();
            R = GUIBackground.transform.FindChild("R").GetComponent<Scrollbar>();
            hMin = GUIBackground.transform.FindChild("hMin").GetComponent<Scrollbar>();
            hMax = GUIBackground.transform.FindChild("hMax").GetComponent<Scrollbar>();
            hOcean = GUIBackground.transform.FindChild("hOcean").GetComponent<Scrollbar>();
            
            SizeText = GUIBackground.transform.FindChild("SizeText").GetComponent<Text>();
            SeedText = GUIBackground.transform.FindChild("SeedText").GetComponent<Text>();
            RText = GUIBackground.transform.FindChild("RText").GetComponent<Text>();
            HMinText = GUIBackground.transform.FindChild("HMinText").GetComponent<Text>();
            HMaxText = GUIBackground.transform.FindChild("HMaxText").GetComponent<Text>();
            HOceanText = GUIBackground.transform.FindChild("HOceanText").GetComponent<Text>();
            
            hMax.onValueChanged.AddListener(delegate(float value) { onHMaxValueChanged(value);});
            hMin.onValueChanged.AddListener(delegate(float value) { onHMinValueChanged(value);});
            hOcean.onValueChanged.AddListener(delegate(float value) { onHOceanValueChanged(value);});
            R.onValueChanged.AddListener(delegate(float value) { onRValueChanged(value);});
            Seed.onValueChanged.AddListener(delegate(float value) { onSeedValueChanged(value);});
            Size.onValueChanged.AddListener(delegate(float value) { onSizeValueChanged(value);});
        }
        
        
        
        private void onHMaxValueChanged(float value)
        {
            PlanetController.Instance.planetPropt.xMax = value*8;
            HMaxText.text = "Max уровень земли: " + value * 8;
            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
        
        private void onHMinValueChanged(float value)
        {
            PlanetController.Instance.planetPropt.xMin = value*8;
            HMinText.text = "Min уровень земли: " + value * 8;
            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
        
        private void onHOceanValueChanged(float value)
        {
            PlanetController.Instance.planetPropt.xOcean = value*10;
            HOceanText.text = "Уровень океана: " + value * 10;
            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
        
        private void onRValueChanged(float value)
        {
            PlanetController.Instance.planetPropt.R = value*10;
            RText.text = "Рельеф: " + value * 10;
            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
        
        private void onSeedValueChanged(float value)
        {
            PlanetController.Instance.planetPropt.Seed = Convert.ToInt32(value*100);
            SeedText.text = "Зерно (Seed): " + Convert.ToInt32(value*100);
            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
        
        private void onSizeValueChanged(float value)
        {
            PlanetController.Instance.planetPropt.Size = Convert.ToInt32(value*12);
            SizeText.text = "Рзмер планеты: " + Convert.ToInt32(value*12);
            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
    }
}