using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    [Header("Snake Movement")]
    public float snakeSpeed = 1f;
    public float turnSpeed = 50f;
    public float minDistance = 1f;
    public float incSpeed = 0.3f;
    public float incTurn = 5f;

    [Header("Snake BodyParts")]
    private GameObject PartsList;

    public int currentNums { get; set; }
    public List<Transform> bodyParts = new List<Transform>();

    [Header("Prefabs and Config")]
    private GameMaster gm;

    public BodyPartMovement tailMovement;
    public SnakeMovement snakeMovement;
    public GameObject bodyPartPrefab;


    // Use this for initialization
    void Start()
    {
        gm = GameMaster.gm;

        //Let the tail follow the Snakehead at start
        tailMovement.target = transform;
        tailMovement.minDistance = minDistance;

        //bodyParts.Add(transform);
        tailMovement.speed = snakeSpeed;
        snakeMovement.speed = snakeSpeed;
        snakeMovement.rotationSpeed = turnSpeed;

        PartsList = GameObject.FindGameObjectWithTag("BodyParts");
    }

    // Update is called once per frame
    void Update()
    {
        updateSpeed();

    }

    void AddBodyPart(int num)
    {
        GameObject newPart = getNewBodyPart(num);

        updateTailTarget(newPart);

        bodyParts.Add(newPart.transform);
    }

    private GameObject getNewBodyPart(int num)
    {
        //Spawn the new part on the location of the last bodyPart of the snake
        Transform spawnPos;
        if (bodyParts.Count == 0)
        {
            spawnPos = snakeMovement.transform;
        }
        else
        {
            spawnPos = bodyParts[bodyParts.Count - 1];

        }
        GameObject newPart = Instantiate(bodyPartPrefab, spawnPos.position, spawnPos.rotation);
        newPart.name = "BodyPart Nr." + bodyParts.Count;


        //Get the BodyPartMovement of the newPart variable
        BodyPartMovement bpm = newPart.GetComponent<BodyPartMovement>();
        if (bpm != null)
        {
            //Print the eaten number on the bodyPart if not 0
            if (num != 0)
            {
                TextMesh mesh = bpm.GetComponentInChildren<TextMesh>();
                mesh.text = num.ToString();
                currentNums += num;
            }
            bpm.target = spawnPos;
            bpm.minDistance = minDistance;
        }
        newPart.transform.position = new Vector3(newPart.transform.position.x, spawnPos.position.y, newPart.transform.position.z);

        newPart.transform.SetParent(PartsList.transform);

        return newPart;
    }
    private void updateTailTarget(GameObject newPart)
    {
        tailMovement.target = newPart.transform;
        tailMovement.StartCoroutine(tailMovement.LetTargetMoveFirst());
    }
    public void increaseMovement()
    {
        snakeSpeed += incSpeed;
        turnSpeed += incTurn;
    }
    private void updateSpeed()
    {
        snakeMovement.speed = snakeSpeed;
        tailMovement.speed = snakeSpeed;
        foreach (Transform part in bodyParts)
        {
            part.GetComponent<BodyPartMovement>().speed = snakeSpeed;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Apple")
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
