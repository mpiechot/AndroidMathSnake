using UnityEngine;

namespace MathSnake.Extensions
{
    public static class GameObjectExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }
            return component;
        }

        public static T GetComponentOrThrow<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                throw new MissingComponentException($"Component of type {typeof(T)} not found on GameObject {gameObject.name}");
            }
            return component;
        }


        public static T GetComponentInChildrenOrThrow<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponentInChildren<T>();
            if (component == null)
            {
                throw new MissingComponentException($"Component of type {typeof(T)} not found on GameObject {gameObject.name} and children.");
            }
            return component;
        }
    }
}
