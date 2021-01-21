
using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace ToDoList_ASP.NET.Extension
{
    public static class ExtensionMethods
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            var stringObject = JsonSerializer.Serialize(value);
            session.SetString(key,stringObject);
        }

        public static T GetObject<T>(this ISession session, string key) where T:class
        {
            var stringObject = session.GetString(key);
            if (String.IsNullOrEmpty(stringObject))
            {
                return null;
            }
            else
            {
                return JsonSerializer.Deserialize<T>(stringObject);
            }
            
        }
    }
}
