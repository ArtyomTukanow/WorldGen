using System;

namespace WorldGen.PlanetGenerator
{
    public class PlanetData
    {

        private PlanetController _controller;

        public PlanetData(PlanetController controller)
        {
            _controller = controller;
        }

        private PlanetPropt Propt
        {
            get { return _controller.planetPropt; }
        }

        public float[] Ground
        {
            get { return _ground; }
        }
        
        
        
        
        
        

        private float[] _ground;
        
        public void GroundGenerate()
        {
            UnityEngine.Random.InitState(Propt.Seed);
            //по размерам карты создаем массив
            _ground = new float[Convert.ToInt32(Math.Pow(2,Propt.Size))];
            float rand = UnityEngine.Random.value * (Propt.xMax - Propt.xMin) + Propt.xMin;
            _ground[_ground.Length - 1] = rand;
            _ground[0] = rand;
            DiamondSquare(rand, rand, 0, _ground.Length);
        }

        private void DiamondSquare(float h1, float h2, int n1, int n2)
        {
            if (n2 - n1 == 1) return;
            float R = (Propt.xMax - Propt.xMin) * Propt.R / Convert.ToSingle(Math.Pow(2, Propt.Size));
            int l = n2 - n1;
            int n = (n1 + n2) / 2;
            float deltaH = UnityEngine.Random.Range(-R * l, R * l);
            float h = (h1 + h2) / 2 + deltaH;
            if (h > Propt.xMax || h < Propt.xMin)
            {
                h -= 2 * deltaH;
            }
            if (h > Propt.xMax || h < Propt.xMin)
            {
                h = Math.Max(h, Propt.xMin);
                h = Math.Min(h, Propt.xMax);
            }
            _ground[n] = h;
            DiamondSquare(h1,h,n1,n);
            DiamondSquare(h,h2,n,n2);
        }
    }
}