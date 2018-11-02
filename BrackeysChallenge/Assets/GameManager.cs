using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float spawnEveryTimer = 10f;
    public float spawnTimerSpeed = 1f;
    public GameObject ball;
    public GameObject player;
    public Text punkteUI;

    private float currentTime;
    private int points = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentTime -= spawnTimerSpeed;
		if( currentTime <= 0)
        {
            currentTime = spawnEveryTimer;
            Vector3 position = new Vector3(Random.Range(-10, 10), Random.Range(5, 15), 0);

            Instantiate(ball, position, Quaternion.identity);
        }
	}
}
