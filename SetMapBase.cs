using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetMapBase : MonoBehaviour
{
    public TileBase baseTile; //Set base tile
    public BoundsInt mapArea; //Size of the tilemap, using input from user
    TileBase[] mapArray;

    //Call function when game starts
    void Start()
    {
        mapArray = new TileBase[mapArea.size.x * mapArea.size.y]; //Array of all tiles in the mapArea
        for (int i = 0; i < mapArray.Length; i++) //Fill mapArray with the base tile
        {
            mapArray[i] = baseTile;
        }
        Tilemap tilemap = GetComponent<Tilemap>(); //Get tilemap game object
        tilemap.SetTilesBlock(mapArea, mapArray); //Set tile array onto the tilemap in the mapArea
    }

}
