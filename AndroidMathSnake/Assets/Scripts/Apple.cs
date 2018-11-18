using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

    public int num { get; set; }
    public GameObject system;
    public MeshRenderer apple;
    private GameMaster gm;

	// Use this for initialization
	void Start () {
        gm = GameMaster.gm;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnDestroy()
    {
        Debug.Log("Destroy?!");
        gm.startAppleDestroy(transform);
    }
}
