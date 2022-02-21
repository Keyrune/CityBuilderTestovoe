using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public SpawnTile[,] tiles = new SpawnTile[10, 10]; 
    public SpawnTile tile;

    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                SpawnTile newTile = Instantiate(tile, new Vector3(i, 0f, j), transform.rotation);
                newTile.index = new Vector2Int(i, j);
                tiles[i, j] = newTile;
            }
        }
    }

}
