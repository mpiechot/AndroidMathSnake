using System;

namespace MathSnake.Player
{
    /// <summary>
    ///    Provides data for the event that is raised when the player dies.
    /// </summary>
    public class DieEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets the cause of the death.
        /// </summary>
        public DeathCause Cause { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DieEventArgs"/> class.
        /// </summary>
        /// <param name="deathCause">The cause of death.</param>
        public DieEventArgs(DeathCause deathCause)
        {
            Cause = deathCause;
        }
    }
}