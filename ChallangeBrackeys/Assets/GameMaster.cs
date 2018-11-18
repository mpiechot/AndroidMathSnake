using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public GameObject ball;
    public float spawnInterval = 10f;
    public float directionVelocity = 10;
    public Text pointsText;

    private float currentTime = 0f;
    private List<GameObject> balls = new List<GameObject>();
    private int points = 0;

	
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
            GameObject newBall = Instantiate(ball, new Vector3(Random.Range(-10, 10), Random.Range(5, 15), 0), Quaternion.identity) as GameObject;
            Rigidbody rb = newBall.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(Random.Range(-directionVelocity, directionVelocity), Random.Range(-5, 5), 0);
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
