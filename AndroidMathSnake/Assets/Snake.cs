using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

    public int currentNums { get; set; }
    public GameObject bodyPartPrefab;
    public List<Transform> bodyParts = new List<Transform>();
    public float minDistance = 1f;

    private GameObject PartsList;

    // Use this for initialization
    void Start () {
        bodyParts.Add(transform);
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
        GameObject newPart;
        if(bodyParts.Count == 1)
        {
            //TODO!!! Schöner machen
            newPart = Instantiate(bodyPartPrefab, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation);
            newPart.transform.position = newPart.transform.position + new Vector3(1, 0, 0);    //Verschiebe den ersten BodyPart um x+1, damit der Head nicht im Bodypart -> GameOver ist
        }
        else{
            newPart = Instantiate(bodyPartPrefab, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation);
        }

        //Increase the speed of the snake
        bodyParts[0].gameObject.GetComponent<SnakeMovement>().speed += 0.3f;

        //Get the BodyPartMovement of the newPart variable
        BodyPartMovement bpm = newPart.GetComponent<BodyPartMovement>();
        if(bpm != null)
        {
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
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("BodyParts"));
        }
    }
}
