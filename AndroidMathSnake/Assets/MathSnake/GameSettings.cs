#nullable enable

using MathSnake.Eatables;
using MathSnake.Player;
using UnityEngine;

namespace MathSnake
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "MathSnake/Game Settings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField]
        public SnakeSettings SnakeSettings { get; private set; } = null!;

        [field: SerializeField]
        public EatableSettings RottingSettings { get; private set; } = null!;
    }
}
