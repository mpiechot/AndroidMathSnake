using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBorad : MonoBehaviour {

    public GameObject[] posUIComponents;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < posUIComponents.Length; i++)
        {
            string name = PlayerPrefs.GetString("name" + i, "-");
            int score = PlayerPrefs.GetInt("score" + i, 0);

            Text scoreUI = Helper.FindComponentInChildWithTag<Text>(posUIComponents[i], "Score");
            Text nameUI = Helper.FindComponentInChildWithTag<Text>(posUIComponents[i], "Player");

            scoreUI.text = score.ToString();
            nameUI.text = name;
        }
	}
}

public static class Helper
{
    public static T FindComponentInChildWithTag<T>(this GameObject parent, string tag) where T : Component
    {
        Transform t = parent.transform;
        foreach (Transform tr in t)
        {
            if (tr.tag == tag)
            {
                return tr.GetComponent<T>();
            }
        }
        return null;
    }
}
