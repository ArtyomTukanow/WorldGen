using System;
using UnityEngine;
using UnityEngine.UI;
using WorldGen.PlanetGenerator;

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
        
        //logic
        private const float HMIN_CONST = 1;
        private const float HMAX_CONST = 10;
        private const float RMAX_CONST = 20;
        private const int SEED_MAX_CONST = 100;
        private const int SIZE_MAX_CONST = 12;
        private const int SIZE_MIN_CONST = 2;
        
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
            
            //перед тем, как подписаться на события, изменим начальное положение GUI элементов
            hMax.value = (PlanetData.HMAX_DEF_CONST - HMIN_CONST)/(HMAX_CONST - HMIN_CONST);
            hMin.value = (PlanetData.HMIN_DEF_CONST - HMIN_CONST)/(HMAX_CONST - HMIN_CONST);
            R.value = PlanetData.R_DEF_CONST/RMAX_CONST;
            hOcean.value = (PlanetData.HOCEAN_DEF_CONST - HMIN_CONST)/(HMAX_CONST - HMIN_CONST);
            Seed.value = (float)PlanetData.SEED_DEF_CONST/SEED_MAX_CONST;
            Size.value = (float) (PlanetData.SIZE_DEF_CONST - SIZE_MIN_CONST) / (SIZE_MAX_CONST - SIZE_MIN_CONST);
            
            hMax.onValueChanged.AddListener(delegate(float value) { onHMaxValueChanged(value);});
            hMin.onValueChanged.AddListener(delegate(float value) { onHMinValueChanged(value);});
            hOcean.onValueChanged.AddListener(delegate(float value) { onHOceanValueChanged(value);});
            R.onValueChanged.AddListener(delegate(float value) { onRValueChanged(value);});
            Seed.onValueChanged.AddListener(delegate(float value) { onSeedValueChanged(value);});
            Size.onValueChanged.AddListener(delegate(float value) { onSizeValueChanged(value);});
        }
        
        
        
        private void onHMaxValueChanged(float value)
        {
            var newValue = HMIN_CONST + value * (HMAX_CONST - HMIN_CONST);
            PlanetController.Instance.planetPropt.HMax = newValue;
            HMaxText.text = "Max уровень земли: " + newValue;
            if (hMax.value < hMin.value)
            {
                hMin.value = hMax.value;
                return;
            }

            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
        
        private void onHMinValueChanged(float value)
        {
            var newValue = HMIN_CONST + value * (HMAX_CONST - HMIN_CONST);
            PlanetController.Instance.planetPropt.HMin = newValue;
            HMinText.text = "Min уровень земли: " + newValue;
            if (hMax.value < hMin.value)
            {
                hMax.value = hMin.value;
                return;
            }
            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
        
        private void onHOceanValueChanged(float value)
        {
            var newValue = HMIN_CONST + value * (HMAX_CONST - HMIN_CONST);
            PlanetController.Instance.planetPropt.HOcean = newValue;
            HOceanText.text = "Уровень океана: " + newValue;
            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
        
        private void onRValueChanged(float value)
        {
            var newWalue = value * RMAX_CONST;
            PlanetController.Instance.planetPropt.R = newWalue;
            RText.text = "Рельеф: " + newWalue;
            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
        
        private void onSeedValueChanged(float value)
        {
            var newValue = Convert.ToInt32(value * SEED_MAX_CONST);
            PlanetController.Instance.planetPropt.Seed = newValue;
            SeedText.text = "Зерно (Seed): " + newValue;
            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
        
        private void onSizeValueChanged(float value)
        {
            var newValue = SIZE_MIN_CONST + Convert.ToInt32(value * (SIZE_MAX_CONST - SIZE_MIN_CONST));
            PlanetController.Instance.planetPropt.Size = newValue;
            SizeText.text = "Размер планеты: " + newValue;
            PlanetController.Instance.Data.GroundGenerate();
            PlanetController.Instance.GameObject.GenerateGameObject();
        }
    }
}