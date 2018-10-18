using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public GameObject apple;
    public Transform ground;
    public Snake snake;
    public float wallThickness = 1;
    public Text currentNumText;
    public Text currentScore;

    private int currentNum;
    private int score = 0;
    private float xLength, zLength;
    private List<GameObject> currentApples = new List<GameObject>();

    void Start()
    {
        xLength = ground.localScale.x - 2*wallThickness;
        zLength = ground.localScale.z - 2*wallThickness;

        currentScore.text = score.ToString();
    }
	// Update is called once per frame
	void Update () {

        if (snake.currentNums >= currentNum)
        {
            if(snake.currentNums == currentNum)
            {
                score += 10;
            }
            else
            {
                score -= 10;
            }
            currentScore.text = score.ToString();
            ResetSnakeBody();
            DeleteRemainingApples();
            CreateNewRandomNum();
            SpawnApplePairs(2);
        }
    }

    void ResetSnakeBody()
    {
        Debug.Log(snake.bodyParts.Count);
        for (int i = 1; i < snake.bodyParts.Count;i++)
        {
            snake.bodyParts[i].gameObject.GetComponentInChildren<TextMesh>().text = "";
        }
        snake.currentNums = 0;
    }
    void DeleteRemainingApples()
    {
        foreach(GameObject apple in currentApples)
        {
            Destroy(apple);
        }
    }
    void CreateNewRandomNum()
    {
        currentNum = Random.Range(2, 100);
        currentNumText.text = currentNum.ToString();
    }

    void SpawnApplePairs(int ammount)
    {
        for(int i = 0; i < ammount; i++)
        {
            SpawnApplePair();
        }
    }
    void SpawnApplePair()
    {
        int firstNum = Random.Range(1, currentNum);
        SpawnApple(firstNum);
        SpawnApple(currentNum - firstNum);
    }
    void SpawnApple(int num)
    {
        float randomX = Random.Range(0, 100);

        GameObject currentApple = Instantiate(apple, ground.position, ground.rotation) as GameObject;       
        currentApple.GetComponent<Apple>().num = num;

        currentApple.transform.position = new Vector3(Random.Range(-(xLength/2), (xLength / 2)), 10, Random.Range(-(xLength / 2), (xLength / 2)));

        currentApples.Add(currentApple);
    }
}
