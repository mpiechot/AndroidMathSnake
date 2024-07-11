namespace MathSnake.Player
{
    /// <summary>
    ///     Enumerates the possible causes of death for the player.
    /// </summary>
    public enum DeathCause
    {
        /// <summary>
        ///     Player died because he hit a wall.
        /// </summary>
        HitWall,

        /// <summary>
        ///    Player died because he hit himself.
        /// </summary>
        HitSelf,
    }
}