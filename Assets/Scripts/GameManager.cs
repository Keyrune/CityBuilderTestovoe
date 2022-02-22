using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one GameManager in scene!");
			return;
		}
		instance = this;
	}


    public bool isBuilding = true;
    public bool isCooking = false;



    public void StartBuilding()
    {
        isBuilding = true;
        isCooking = false;
    }

    public void StartCooking()
    {
        isBuilding = false;
        isCooking = true;
    }
}
