using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public MeshRenderer renderer;
    public GameMaster gm;

	// Use this for initialization
	void Start () {
        // Color color = new Color(Random.value, Random.value, Random.value);
        renderer.material.color = Color.red;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>() ;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -5)
        {
            if(renderer.material.color == Color.red)
            {
                gm.increasePoints(-20);
            }
            gameObject.active = false;
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if(renderer.material.color == Color.red)
            {
                renderer.material.color = Color.white;
                gm.increasePoints(20);
            }
        }
    }
}
