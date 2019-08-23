using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Assets.Runtime.Scripts.JsonParser
{
    public class JsonParser : IParser
    {
        public string jsonData { get; private set; }

        public JsonParser(string jsonData)
        {
            this.jsonData = jsonData;
        }

        public virtual void Parse()
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(jsonData));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    Debug.Log($"Token: {reader.TokenType}, Value: {reader.Value}");
                }
                else
                {
                    Debug.Log($"Token: {reader.TokenType}");
                }
            }
        }
        protected List<T> ConvertJTokensToList<T>(IList<JToken> tokens)
        {
            List<T> results = new List<T>();
            foreach (JToken token in tokens)
            {
                results.Add(token.ToObject<T>());
            }
            return results;
        }
    }
}
