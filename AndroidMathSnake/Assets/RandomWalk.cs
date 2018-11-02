using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour {

    private float speed = 2f;
    private Vector3 moveVector;
    private float timer = 0;

    // Use this for initialization
    void Start () {
        moveVector= new Vector3(Random.value * (Random.value >= 0.5? -1 : 1), 0, Random.value * (Random.value >= 0.5 ? -1 : 1));
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer -= 0.2f;
        if(timer <= 0)
        {
            Debug.Log("Timeup");
            moveVector = new Vector3(Random.value * (Random.value >= 0.5 ? -1 : 1), 0, Random.value * (Random.value >= 0.5 ? -1 : 1));
            speed = Random.Range(1, 5);
            timer = Random.Range(1, 50);
        }
        transform.Translate(moveVector * speed * Time.deltaTime, Space.Self);
    }

}
