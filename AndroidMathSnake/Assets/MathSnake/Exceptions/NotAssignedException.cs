#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;

namespace MathSnake.Exceptions
{
    /// <summary>
    /// Represents errors that occur when a field or property is accessed before it has been assigned a value.
    /// This exception is specifically designed to be thrown in scenarios where a field or property
    /// is expected to be assigned a value before being accessed, but was found to be unassigned at runtime.
    /// This aids in identifying and debugging issues related to the premature access of unassigned members.
    /// </summary>

    [Serializable]
    public class NotAssignedException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NotAssignedException"/> class.
        /// </summary>
        /// <param name="filePath">The path of the file where the unassigned field was found. This parameter is automatically populated by the compiler.</param>
        /// <param name="callerMemberName">The name of the member (method, property, etc.) where the unassigned field was detected. This parameter is automatically populated by the compiler.</param>
        public NotAssignedException([CallerFilePath] string filePath = "", [CallerMemberName] string callerMemberName = "") :
            base($"The object '{callerMemberName}' of '{Path.GetFileName(filePath)}' was accessed before Initialize was called.")
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
        /// <exception cref="NotAssignedException">Throws the exception if the given object is null.</exception>
        public static T ThrowIfNull<T>([NotNull] T? obj, [CallerFilePath] string filePath = "", [CallerMemberName] string callerMemberName = "")
            where T : class
        {
            if (obj == null)
            {
                throw new NotAssignedException(filePath, callerMemberName);
            }

            return obj;
        }
    }
}
