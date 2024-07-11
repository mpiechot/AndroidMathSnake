using UnityEngine;

namespace MathSnake.Player
{
    public static class SnakeSpawner
    {
        public static Snake SpawnSnake(GameContext context)
        {
            var newSnake = GameObject.Instantiate(context.SnakeSettings.SnakePrefab);
            newSnake.Initialize(context);
            return newSnake;
        }
    }
}
