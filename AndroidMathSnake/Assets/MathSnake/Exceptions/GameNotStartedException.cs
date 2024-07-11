#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;

namespace MathSnake.Exceptions
{
    /// <summary>
    ///     Represents errors that occur when an operation is attempted on a game object or component
    ///     before the game has been properly started. This exception is specifically designed to be thrown
    ///     in scenarios where game objects or components are accessed or manipulated before the game's
    ///     initialization process is complete, indicating that the StartGame method of the GameManager
    ///     was never called. This aids in identifying and debugging issues related to game start-up sequences.
    /// </summary>
    [Serializable]
    public class GameNotStartedException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GameNotStartedException"/> class.
        /// </summary>
        /// <param name="filePath">The path of the file where the unassigned field was found. This parameter is automatically populated by the compiler.</param>
        /// <param name="callerMemberName">The name of the member (method, property, etc.) where the unassigned field was detected. This parameter is automatically populated by the compiler.</param>
        public GameNotStartedException([CallerFilePath] string filePath = "", [CallerMemberName] string callerMemberName = "") :
            base($"The object '{callerMemberName}' of '{Path.GetFileName(filePath)}' was null because StartGame of the GameManager was never called.")
        {
        }

        /// <summary>
        ///     Checks if the object is null and throws an exception if it is.
        /// </summary>
        /// <typeparam name="T">The type of the object to check.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="filePath">The filepath of the objects class.</param>
        /// <param name="callerMemberName">The caller name of the object to check.</param>
        /// <returns>The non-nullable object if the given object is not null.</returns>
        /// <exception cref="GameNotStartedException">Throws the exception if the given object is null.</exception>
        public static T ThrowIfNull<T>([NotNull] T? obj, [CallerFilePath] string filePath = "", [CallerMemberName] string callerMemberName = "")
            where T : class
        {
            if (obj == null)
            {
                throw new GameNotStartedException(filePath, callerMemberName);
            }

            return obj;
        }
    }
}
