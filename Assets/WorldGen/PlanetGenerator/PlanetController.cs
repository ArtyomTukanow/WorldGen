using UnityEngine;
using WorldGen.PlanetGenerator;

namespace WorldGen
{
    public class PlanetController
    {
        
        private PlanetController() {}
        
        private static PlanetController instance = new PlanetController();

        public static PlanetController Instance
        {
            get { return instance; }
        }

//        public PlanetPropt Propt
//        {
//            get {
//                return _planetPropt;
//            }
//        }
        public PlanetData Data
        {
            get {
                return _planetData;
            }
        }
        public PlanetGameObject GameObject
        {
            get {
                return _planetGameObject;
            }
        }
        
        public PlanetPropt planetPropt;
        private PlanetData _planetData;
        private PlanetGameObject _planetGameObject;

        public Main Parent;
        
        
        public void GenerateNewPlanet(PlanetPropt propt)
        {
            planetPropt = propt;
            _planetData = new PlanetData(this);
            _planetGameObject = new PlanetGameObject(this);
            _planetData.GroundGenerate();
            _planetGameObject.GenerateGameObject();
        }
    }
}