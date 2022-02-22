using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grid : MonoBehaviour
{
    public SpawnTile[,] tiles = new SpawnTile[10, 10]; 
    public SpawnTile grassTile;
    public SpawnTile sandTile;
    public SpawnTile swampTile;
    public SpawnTile waterTile;


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
                SpawnTile newTile = Instantiate(grassTile, new Vector3(i, 0f, j), transform.rotation);
                newTile.index = new Vector2Int(i, j);
                
                tiles[i, j] = newTile;

            }
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                int randomNuber = Random.Range(0, 100);
                if (randomNuber <= 5 )
                {
                    tiles[i, j].ChangeSurface(3);

                }
                else if (randomNuber <= 10 )
                {
                    tiles[i, j].ChangeSurface(2);
                }

            }
        }



        
    }

}
