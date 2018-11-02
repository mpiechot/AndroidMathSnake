using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public GameObject ball;
    public float spawnInterval = 10f;
    public Text pointsText;
    public static GameMaster gm;

    private float currentTime = 0f;
    private List<GameObject> balls = new List<GameObject>();
    private int points = 0;

	// Use this for initialization
	void Awake () {
		if(gm == null)
        {
            gm = new GameMaster();
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = balls.Count-1; i >= 0; i--)
        {
            if (!balls[i].activeInHierarchy)
            {
                GameObject ball = balls[i];
                balls.RemoveAt(i);
                Destroy(ball);
                continue;
            }
            if(balls[i].transform.position.y <= -5 && balls[i].GetComponent<MeshRenderer>().material.color == Color.red)
            {
                Debug.Log("GameOver");
            }
        }

        currentTime -= 0.5f;
        if (currentTime <= 0)
        {
            GameObject newBall = Instantiate(ball, new Vector3(Random.Range(-5, 5), Random.Range(5, 15), 0), Quaternion.identity) as GameObject;
            balls.Add(newBall);


            currentTime = spawnInterval;
        }
	}
    public void increasePoints(int val)
    {
        points += val;
        pointsText.text = points.ToString();
    }
}
