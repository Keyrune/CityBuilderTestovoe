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


	void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
    }

	void OnMouseDown ()
	{

		BuildManager.instance.Build(index.x, index.y, 2);
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
        if (isEmpty & surface < 2)
            return true;
        return false;
    }

}
