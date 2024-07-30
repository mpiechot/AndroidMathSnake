using MathSnake.Eatables;
using MathSnake.Player;

namespace MathSnake
{
    public interface IGameController
    {
        StomachResult EvaluateStomach(IEatable eatable);

        void StartGame(GameContext gameContext);
    }
}