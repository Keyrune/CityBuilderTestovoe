using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
    
	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

    public Vector3 positionOffset = new Vector3(-0.5f, 0.5f, -0.5f);
    public Grid grid;
	public Building buildingPrefab1;
	public Building buildingPrefab2;
	public Building buildingPrefab3;
    private Building selectedBuilding;
    private int buildingSize;
    private List<Building> buildings;


	void Start ()
	{
		selectedBuilding = buildingPrefab1;
        buildingSize = 1;
	}


    public void Build(int x, int y)
    {
        int size = buildingSize;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {       
                if (x+i > 9 || y+j > 9) return;

                if (!grid.tiles[x+i, y+j].CanBuild())
                    return;
            }
        }


        Building newBuilding = Instantiate(selectedBuilding, new Vector3(x, 0f, y) + positionOffset, transform.rotation);
        newBuilding.size = size;
        newBuilding.position = new Vector2(x, y);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {       
                grid.tiles[x+i, y+j].isEmpty = false;
            }
        }
    }

    public void ChangeBuildingSize(int size)
    {
        buildingSize = size;
        switch (size)
        {
            case 1:
                selectedBuilding = buildingPrefab1;
                break;
            case 2:
                selectedBuilding = buildingPrefab2;
                break;
            case 3:
                selectedBuilding = buildingPrefab3;
                break;
            default:
                selectedBuilding = buildingPrefab1;
                break;
        }
    }

    public bool CheckTiles(int[,] tiles)
    {   
        return true;
    }

}