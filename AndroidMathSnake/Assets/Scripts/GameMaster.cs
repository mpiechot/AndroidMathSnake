using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public GameObject apple;
    public Transform ground;
    public Snake snake;
    public float wallThickness = 1;
    public GameObject searchNumberField;
    public TextMesh currentScore;
    public GameObject[] numbers = new GameObject[10];
    public static GameMaster gm;
    public GameObject appleDestroyAnim;
    public float currentRotTime;
    public int[] raiseDifficultyLevels = { 1, 2, 3, 4 };
    public int[] difficultysMax = { 20, 50, 100 , 100};
    public int[] difficultysMin = { 3, 20, 50, 30 };
    public int currentLevel = 0;
    public int currentDiffculty = 0;
    

    protected Vector3 worldSize;

    private int currentNum;
    private int score = 0;
    private float xLength, zLength;
    private List<GameObject> currentApples = new List<GameObject>();
    private List<GameObject> currentNumObjects = new List<GameObject>();
    private List<Vector3> destroyAppleAnims = new List<Vector3>();

    void Awake()
    {
        gm = this;
    }

    void Start()
    {
        worldSize = ground.GetComponent<MeshRenderer>().bounds.size;
        xLength = worldSize.x - 2*wallThickness;
        zLength = worldSize.z - 2*wallThickness;
        currentRotTime = 0f;

        currentScore.text = score.ToString();
    }

    public GameMaster getInstance()
    {
        return gm;
    }
    public void startAppleDestroy(Transform apple)
    {
        destroyAppleAnims.Add(apple.position);
        currentApples.Remove(apple.gameObject);
    }
	// Update is called once per frame
	void Update () {
        if(destroyAppleAnims.Count > 0)
        {
            for(int i=destroyAppleAnims.Count-1;i>=0;i--)
            {
                Instantiate(appleDestroyAnim, destroyAppleAnims[i], appleDestroyAnim.transform.rotation);
                destroyAppleAnims.RemoveAt(i);
            }
        }
        if (snake.currentNums >= currentNum || currentApples.Count == 0)
        {
            currentLevel++;
            if(currentDiffculty < raiseDifficultyLevels.Length-1 && currentLevel > raiseDifficultyLevels[currentDiffculty + 1])
            {
                currentDiffculty++;
            }
            if(currentDiffculty == raiseDifficultyLevels.Length - 1)
            {
                currentRotTime = 0.001f;
            }
            else
            {
                snake.increaseMovement();
            }
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
            if (currentDiffculty != raiseDifficultyLevels.Length - 1)
                DeleteRemainingApples();
            CreateNewRandomNum();
            SpawnApplePairs(3);
        }
    }

    void ResetSnakeBody()
    {
        for (int i = 0; i < snake.bodyParts.Count;i++)
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
        ClearCurrentNumObjects();
        currentNum = Random.Range(difficultysMin[currentDiffculty], difficultysMax[currentDiffculty]);
        CreateNumObjectsInList(currentNum, searchNumberField.transform);
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
        GameObject currentApple = Instantiate(apple, Vector3.zero, Quaternion.identity) as GameObject;
        
        currentApple.transform.position = new Vector3(Random.Range(-(xLength/2), (xLength / 2)), 10, Random.Range(-(zLength / 2), (zLength / 2)));

        currentApple.GetComponent<Apple>().num = num;

        CreateNumObjects(num, currentApple.transform);
        
        currentApples.Add(currentApple);
    }
    private void CreateNumObjectsInList(int num, Transform parent)
    {
        float moveX = (num < 10 ? -0.8f : -0.2f);
        int xPlus = -1;
        while (num != 0)
        {
            int digit = num % 10;
            num /= 10;
            Vector3 numPos = new Vector3(parent.position.x + moveX, parent.position.y, parent.position.z - 0.7f);
            GameObject digitObj = Instantiate(numbers[digit], numPos, numbers[digit].transform.rotation) as GameObject;
            currentNumObjects.Add(digitObj);
            moveX += xPlus;
            digitObj.transform.parent = parent;
        }
    }
    private void CreateNumObjects(int num, Transform parent)
    {
        float moveX = (num < 10 ? -0.8f : -0.2f);
        int xPlus = -1;
        while (num != 0)
        {
            int digit = num % 10;
            num /= 10;
            Vector3 numPos = new Vector3(parent.position.x + moveX, parent.position.y + 1f, parent.position.z - 0.7f);
            GameObject digitObj = Instantiate(numbers[digit], numPos, numbers[digit].transform.rotation) as GameObject;
            moveX += xPlus;
            digitObj.transform.parent = parent;
        }
    }
    private void ClearCurrentNumObjects()
    {
            Debug.Log("Destroy: ");
        for(int i= currentNumObjects.Count - 1; i >= 0; i--)
        {
            GameObject delete = currentNumObjects[i];
            currentNumObjects.RemoveAt(i);
            Destroy(delete);
        }
    }

}
