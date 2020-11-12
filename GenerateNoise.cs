using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNoise : MonoBehaviour
{
    System.Random random = new System.Random();
    private int seed; //offset the noise, Perlin Noise will always produce the same noise
    float[] pNoiseArray;
    public float scale = 1.0f; //Changes the size of waves of noise
    private int width;
    private int height;

    void Start()
    {
        seed = random.Next();
        width = GameObject.Find("Tilemap").GetComponent<SetMapBase>().mapArea.size.x;
        height = GameObject.Find("Tilemap").GetComponent<SetMapBase>().mapArea.size.y;

        pNoiseArray = new float[width * height]; //pNosieArray same size as the mapArray
    }

    void CalcNoise() //Use Perlin Noise to determine spread of the tiles
    {
        for (float i = 0f; i < height; i++) //Loop through Perlin Noise algorithm to fill the array
        {
            for (float j = 0f; j < width; j++)
            {
                float x = j + seed / width * scale;
                float y = i + seed / height * scale;
                float pNoise = Mathf.PerlinNoise(x, y); //Perlin Noise Function, pass in x and y coord
                pNoiseArray[(int)i * height + (int)j] = pNoise; //2d map to 1d array
            }
        }
    }
}
