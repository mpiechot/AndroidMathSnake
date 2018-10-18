using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

    public int num { get; set; }
    public TextMesh text;

	// Use this for initialization
	void Start () {    
        text = GetComponentInChildren<TextMesh>();
        text.text = num.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
