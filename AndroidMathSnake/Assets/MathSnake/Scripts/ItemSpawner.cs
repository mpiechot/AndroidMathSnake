#nullable enable

using MathSnake.Exceptions;
using UnityEngine;

namespace MathSnake.Eatables
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField]
        private Apple? applePrefab;

        [SerializeField]
        private Transform? appleParent;

        private GameContext? gameContext;

        private Apple ApplePrefab => SerializeFieldNotAssignedException.ThrowIfNull(applePrefab);

        private Transform AppleParent => SerializeFieldNotAssignedException.ThrowIfNull(appleParent);

        private GameContext GameContext => NotInitializedException.ThrowIfNull(gameContext);

        public void Initialize(GameContext context)
        {
            gameContext = context;
        }

        public Apple SpawnApple(int number, Vector3 position)
        {

            var spawnedApple = Instantiate(ApplePrefab, position, Quaternion.identity, AppleParent);
            spawnedApple.Initialize(number, GameContext);
            spawnedApple.gameObject.name = $"Apple ({number})";

            return spawnedApple;
        }
    }
}
//void SpawnApplePairs(int ammount)
//{
//    for (int i = 0; i < ammount; i++)
//    {
//        SpawnApplePair();
//    }
//}
//void SpawnApplePair()
//{
//    int firstNum = Random.Range(1, currentNum);
//    SpawnApple(firstNum);
//    SpawnApple(currentNum - firstNum);
//}

//void SpawnApple(int num)
//{
//GameObject currentApple = Instantiate(apple, Vector3.zero, Quaternion.identity) as GameObject;

//currentApple.transform.position = new Vector3(Random.Range(-(xLength / 2), (xLength / 2)), 10, Random.Range(-(zLength / 2), (zLength / 2)));

//currentApple.GetComponent<Apple>().num = num;

//CreateNumObjects(num, currentApple.transform);

//currentApples.Add(currentApple);
//    }
//}
//}
