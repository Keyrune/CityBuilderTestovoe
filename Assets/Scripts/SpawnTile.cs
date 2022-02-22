using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public Color hoverColor;
	public Vector3 positionOffset;

	private GameObject building;
    public Vector2Int index;

	private Renderer rend;
	private Color startColor;
    public bool isEmpty = true;
    public int surface = 0;


	void Awake ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
    }

	void OnMouseDown ()
	{
		if (GameManager.instance.isBuilding == true)
			BuildManager.instance.Build(index.x, index.y);
		if (GameManager.instance.isCooking == true)
			Cook();
		// building = (GameObject)Instantiate(newBuilding, transform.position + positionOffset, transform.rotation);
	}

	void OnMouseEnter ()
	{
		rend.material.color = hoverColor;
	}

	void OnMouseExit ()
	{
		rend.material.color = startColor;
    }

    public bool CanBuild()
    {
        if (!isEmpty)
			return false;
		if (surface > 1)
            return false;
        return true;
    }

	public void Cook() 
	{
		if (surface == 2) ChangeSurface(1);
		if (surface == 3) ChangeSurface(2);
	}

	public void ChangeSurface(int id) 
	{
		if (rend.material == null) return;

		switch (id)
		{
			case 0: // grass
				surface = 0;
				rend.material.color = startColor;
				break;
			case 1: // sand
				surface = 1;
				rend.material.color = Color.yellow;
				startColor = Color.yellow;
				break;
			case 2: // swamp
				surface = 2;
				rend.material.color = Color.black;
				startColor = Color.black;
				break;
			case 3: // water
				surface = 3;
				rend.material.color = Color.blue;
				startColor = Color.blue;
				break;

		}
	}

}
