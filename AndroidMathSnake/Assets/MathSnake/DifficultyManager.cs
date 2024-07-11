namespace MathSnake.Assets.MathSnake
{
    // TODO refactor this class.
    public class DifficultyManager
    {
        private int[] raiseDifficultyLevels = { 1, 2, 3, 4 };

        private int[] difficultysMax = { 20, 50, 100, 100 };

        private int[] difficultysMin = { 3, 20, 50, 30 };

        public int CurrentDifficulty { get; private set; }

        public DifficultyManager()
        {
            CurrentDifficulty = 0;
        }
    }
}
