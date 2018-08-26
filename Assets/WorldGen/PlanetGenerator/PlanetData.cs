using System;

namespace WorldGen.PlanetGenerator
{
    public class PlanetData
    {
        //defaults values
        public const float HMIN_DEF_CONST = 3;
        public const float HMAX_DEF_CONST = 5;
        public const float HOCEAN_DEF_CONST = 4;
        public const float R_DEF_CONST = 2;
        public const int SEED_DEF_CONST = 0;
        public const int SIZE_DEF_CONST = 8;

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
            float rand = UnityEngine.Random.value * (Propt.HMax - Propt.HMin) + Propt.HMin;
            _ground[_ground.Length - 1] = rand;
            _ground[0] = rand;
            DiamondSquare(rand, rand, 0, _ground.Length);
        }

        private void DiamondSquare(float h1, float h2, int n1, int n2)
        {
            if (n2 - n1 == 1) return;
            float R = (Propt.HMax - Propt.HMin) * Propt.R / Convert.ToSingle(Math.Pow(2, Propt.Size));
            int l = n2 - n1;
            int n = (n1 + n2) / 2;
            float deltaH = UnityEngine.Random.Range(-R * l, R * l);
            float h = (h1 + h2) / 2 + deltaH;
            if (h > Propt.HMax || h < Propt.HMin)
            {
                h -= 2 * deltaH;
            }
            if (h > Propt.HMax || h < Propt.HMin)
            {
                h = Math.Max(h, Propt.HMin);
                h = Math.Min(h, Propt.HMax);
            }
            _ground[n] = h;
            DiamondSquare(h1,h,n1,n);
            DiamondSquare(h,h2,n,n2);
        }
    }
}