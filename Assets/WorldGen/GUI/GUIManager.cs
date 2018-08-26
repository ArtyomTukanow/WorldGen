using UnityEngine;

namespace WorldGen.GUI
{
    public class GUIManager
    {
        //GUI Layers:
        public static NewPlanetGUI NewPlanetGui;
        private static RectTransform MainRectTransform;
        public static Vector2 RectSize
        {
            get { return MainRectTransform.sizeDelta; }
        }
            
            
        public static void CreateGUI(RectTransform rectTransform)
        {
            MainRectTransform = rectTransform;
            NewPlanetGui = new NewPlanetGUI(rectTransform.transform);
        }
    }
}