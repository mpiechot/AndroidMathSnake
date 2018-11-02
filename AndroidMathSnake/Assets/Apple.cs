using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

    public int num { get; set; }
    public GameObject system;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnDestroy()
    {
        Debug.Log("Destroy?!");
        Instantiate(system, transform.position, system.transform.rotation);
    }
}
