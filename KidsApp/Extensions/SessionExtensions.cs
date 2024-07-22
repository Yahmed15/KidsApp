// KidsApp/Extensions/SessionExtensions.cs
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KidsApp.Extensions
{
    public static class SessionExtensions
    {
        // Stores an object as a JSON string in the session
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // Serialize the object to JSON and store it in the session with the given key
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Retrieves an object from the session that was stored as a JSON string
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            // Get the JSON string from the session using the given key
            var value = session.GetString(key);

            // If the value is null, return the default value for the type T
            // Otherwise, deserialize the JSON string back into the object of type T
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        // Optionally: Method to clear a specific item from the session
        public static void RemoveObject(this ISession session, string key)
        {
            // Remove the object associated with the key from the session
            session.Remove(key);
        }

        // Optionally: Method to clear all session data
        public static void ClearAll(this ISession session)
        {
            // Clear all keys and their associated values from the session
            foreach (var key in session.Keys)
            {
                session.Remove(key);
            }
        }
    }
}
