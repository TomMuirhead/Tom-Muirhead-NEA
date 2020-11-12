using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : TileBase
{
    private bool canTraverse;
    private int resource;
    private int defence;
    private int baseConnection;

    public Tile()
    {
        canTraverse = true;
        resource = 0;
        defence = 0;
        baseConnection = 0;
    }

    public class DeepWater : Tile
    {
        public DeepWater() : base()
        {
            canTraverse = false;
            resource = 10;
            defence = 20;
        }
    }
    public class ShallowWater :Tile
    {
        public ShallowWater() : base()
        {
            canTraverse = false;
            resource = 20;
            defence = 5;
        }
    }
    public class Beach : Tile
    {
        public Beach() : base()
        {
            resource = 10;
        }
    }
    public class Plain : Tile
    {
        public Plain() : base()
        {
            resource = 15;
            defence = 5;
        }
    }
    public class Forest : Tile
    {
        public Forest() : base()
        {
            resource = 10;
            defence = 10;
        }
    }
    public class Hills : Tile
    {
        public Hills() : base()
        {
            resource = 5;
            defence = 20;
        }
    }
    public class Mountain : Tile
    {
        public Mountain() : base()
        {
            canTraverse = false;
            resource = 5;
            defence = 30;
        }
    }
    public class Snow : Tile
    {
        public Snow() : base()
        {
            canTraverse = false;
            defence = 10;
        }
    }
}
/*
public class TileType : MonoBehaviour
{
    public TileBase
    baseTile, deepWater, shallowWater, beach, plain, forest, hills, mountain, snow;

    
    public void AssignTile(float[] pNoiseArray)
    {
        for (int i = 0; i < pNoiseArray.Length; i++) //Loop through tilemap array
        {
            switch (pNoiseArray[i]) //Assign tile type according to Perlin Noise value
            {
                case float n when n >= 0 && n < 0.125: //Perlin Noise gives value between 0 and 1
                    setDeepWater(i); //Calling function to change tile, passing tile index
                    break;
                case float n when n >= 0.125 && n < 0.25:
                    setShallowWater(i);
                    break;
                case float n when n >= 0.25 && n < 0.375:
                    setBeach(i);
                    break;
                case float n when n >= 0.375 && n < 0.5:
                    setPlain(i);
                    break;
                case float n when n >= 0.5 && n < 0.625:
                    setForest(i);
                    break;
                case float n when n >= 0.625 && n < 0.75:
                    setHills(i);
                    break;
                case float n when n >= 0.75 && n < 0.875:
                    setMountain(i);
                    break;
                case float n when n >= 0.875 && n <= 1:
                    setSnow(i);
                    break;
                default:
                    break;
            }
        }
    }

    private void setDeepWater(int i) //Set tile to Deep Water Tile
    {
        deepWater = new Tile.DeepWater(); //Instantiate Deep Water Tile
        mapArray[i] = deepWater; //Set tile at index i to Deep Water tile
    }
    private void setShallowWater(int i)
    {
        shallowWater = new Tile.ShallowWater();
        mapArray[i] = shallowWater;
    }
    private void setBeach(int i)
    {
        beach = new Tile.Beach();
        mapArray[i] = beach;
    }
    private void set(int i)
    {
        plain = new Tile.Plain();
        mapArray[i] = plain;
    }
}
*/