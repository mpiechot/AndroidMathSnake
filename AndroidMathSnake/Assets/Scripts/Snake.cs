using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour {

    public int currentNums { get; set; }
    public GameObject bodyPartPrefab;
    public List<Transform> bodyParts = new List<Transform>();
    public TailMovement tail;
    public float minDistance = 1f;

    private GameObject PartsList;

    // Use this for initialization
    void Start () {
        tail.target = transform;
        tail.minDistance = minDistance;
        bodyParts.Add(transform);
        tail.speed = bodyParts[0].gameObject.GetComponent<SnakeMovement>().speed;
        PartsList = GameObject.FindGameObjectWithTag("BodyParts");
        //for(int i = 0; i < 10; i++)
        //{
       //     AddBodyPart(0);
       // }
	}
	
	// Update is called once per frame
	void Update () {

       
	}

    void AddBodyPart(int num)
    {
        //Spawn the new part on the location of the last bodyPart of the snake
        GameObject newPart = Instantiate(bodyPartPrefab, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation);
        newPart.name = "BodyPart Nr." + bodyParts.Count;
        tail.target = newPart.transform;
        tail.StartCoroutine(tail.LetTargetMoveFirst());

        //Increase the speed of the snake and its bodyParts
        bodyParts[0].gameObject.GetComponent<SnakeMovement>().speed += 0.3f;
        tail.speed += 0.3f;
        for(int i = 1;i< bodyParts.Count;i++)
        {
            bodyParts[i].GetComponent<BodyPartMovement>().speed += 0.3f;
        }

        //Get the BodyPartMovement of the newPart variable
        BodyPartMovement bpm = newPart.GetComponent<BodyPartMovement>();
        if(bpm != null)
        {
            //Print the eaten number on the bodyPart if not 0
            if (num != 0)
            {
                TextMesh mesh = bpm.GetComponentInChildren<TextMesh>();
                mesh.text = num.ToString();
                currentNums += num;
            }
            bpm.target = bodyParts[bodyParts.Count - 1];
            bpm.minDistance = minDistance;
            bpm.speed = bodyParts[0].gameObject.GetComponent<SnakeMovement>().speed;

        }
        newPart.transform.position = new Vector3(newPart.transform.position.x, bodyParts[0].position.y, newPart.transform.position.z);

        newPart.transform.SetParent(PartsList.transform);

        bodyParts.Add(newPart.transform);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Apple")
        {
            AddBodyPart(col.gameObject.GetComponent<Apple>().num);
            Destroy(col.gameObject);
        }
        if (col.tag == "GameOver")
        {
            Debug.Log("Snake hit: " + col.name + " -> " + col.tag);
            PlayerValues.Score = Int32.Parse(GameMaster.gm.currentScore.text);
            StartCoroutine(StartUIControll.focusOn());
            SceneManager.LoadScene("UpdateHighScore");
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("BodyParts"));
        }
    }
}
