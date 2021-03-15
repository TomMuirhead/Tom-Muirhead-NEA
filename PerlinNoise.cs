using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Game
{
	class PerlinNoise
    {
        private FastNoiseLite NoiseGen;
        private Random rnd;
        private int seed;
        private float scale = 0.005f;

        private float[,] noiseArray;
        
        public PerlinNoise(int x, int y)
        {
            noiseArray = new float[x, y];
            rnd = new Random();

			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < y; j++)
				{
                    noiseArray[i, j] = (float)rnd.Next(101)/(float)100;
				}
			}  
        }
            /*
            NoiseGen = new FastNoiseLite(); // Library referance not working
            NoiseGen.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
            
            rnd = new Random();
            seed = rnd.Next();
            
            NoiseGen.SetSeed(seed);
            NoiseGen.SetFrequency(scale);
            */

        public float GetNoise(int x, int y)
        {
            //return NoiseGen.GetNoise(x, y);
            return noiseArray[x, y];
        }

    }
}
