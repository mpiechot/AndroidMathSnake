using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct sMapObjectInfo
{
	public sMapObjectInfo(string n, Vector3 p, Vector3 r)
	{
		string[] temp = n.Split (new string[]{ "(", " "  }, System.StringSplitOptions.RemoveEmptyEntries);
			
		objName = temp != null && temp.Length > 1 ? temp[0] : n;

		pos = p; rot = r;	
	}

	public string objName;
	public Vector3 pos;
	public Vector3 rot;
}

public class EnviromentManager : MonoBehaviour {

	public GameObject world = null;
	public GameObject groundParent = null;
	public GameObject mapObjectsParent = null;

	public bool GUI_ON = true;

	private List<GameObject> grounds = new List<GameObject>();
	private List<GameObject> mapObjects = new List<GameObject>();

	private int actTheme  = 0;

	void Awake()
	{
		for (int i = 0; i < groundParent.transform.childCount; i++)
		{
			grounds.Add (groundParent.transform.GetChild (i).gameObject);
		}

		for (int i = 0; i < mapObjectsParent.transform.childCount; i++)
		{
			mapObjects.Add (mapObjectsParent.transform.GetChild (i).gameObject);
		}
	}

	private string[] themeNames = {
		"ASIA",
		"FOREST",
		"DESERT",
		"BALLROOM",
		"STADIUM",
		"URBAN"
	};

	private string[] resNames = {
		"ThemeAsia",
		"ThemeForest",
		"ThemeDesert",
		"ThemeBallRoom",
		"ThemeStadium",
		"ThemeUnknown"
	};

	private string[] groundResNames = {
		"Asia_1",
		"Forest_1",
		"Desert_1",
		"BallRoom_1",
		"Stadium_1",
		"Unknown_1"
	};

	const float eButtonWidth = 120;
	Vector2 btn = new Vector2(0,0);
	void OnGUI()
	{
		if (!GUI_ON)
			return;
		for (int i = 0; i < themeNames.Length; i++)
		{
			btn.x = (i < 3) ? 10 + (i * (eButtonWidth + 10)) : 10 + ((i-3) * (eButtonWidth + 10));
			btn.y = (i < 3) ? 40 : 80;
			if (GUI.Button (new Rect (btn.x, btn.y, eButtonWidth, 40), i == actTheme ? ">>" + themeNames [i] + "<<" : themeNames [i]))
			{
				if (!isChanging && actTheme != i)
				{
					actTheme = i;
					changeTheme ();
				}
			}
		}	
	}

	private bool isChanging = false;
	private void changeTheme()
	{
		isChanging = true;
		StartCoroutine (_changeTheme());
	}


	IEnumerator _changeTheme()
	{
		sMapObjectInfo[] mapObjectInfos = new sMapObjectInfo[mapObjects.Count];
		for (int i = 0; i < mapObjects.Count; i++)
		{
			mapObjectInfos [i] = new sMapObjectInfo (mapObjects [i].gameObject.name, mapObjects [i].transform.position, mapObjects [i].transform.eulerAngles);
			GameObject.Destroy (mapObjects [i]);
		}
		mapObjects.Clear ();

		int groundCount = grounds.Count;
		Vector3[] groundPos = new Vector3[groundCount];
		for (int i = 0; i < groundCount; i++)
		{
			groundPos [i] = grounds [i].transform.position;
			GameObject.Destroy (grounds [i]);
		}
		grounds.Clear ();

		yield return null;
		yield return null;

		for (int i = 0; i < groundCount; i++)
		{
			Object groundObj = Resources.Load (resNames [actTheme] + "/Ground/" + groundResNames [actTheme]);
			GameObject groundGO = GameObject.Instantiate (groundObj) as GameObject;

			groundGO.transform.parent = groundParent.transform;
			groundGO.transform.position = groundPos [i];

			grounds.Add (groundGO);
		}

		for (int i = 0; i < mapObjectInfos.Length; i++)
		{
			Object mapResObj = Resources.Load (resNames [actTheme] + "/" + mapObjectInfos [i].objName);
			GameObject mapGO = GameObject.Instantiate (mapResObj) as GameObject;

			mapGO.transform.parent = mapObjectsParent.transform;
			mapGO.transform.position = mapObjectInfos [i].pos;
			mapGO.transform.eulerAngles = mapObjectInfos [i].rot;

			mapObjects.Add (mapGO);
		}

		yield return null;
		isChanging = false;
	}
}
