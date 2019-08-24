using System.Collections.Generic;
using System.IO;
using Assets.Runtime.Scripts.JsonParser.DataTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Assets.Runtime.Scripts.JsonParser
{
    public class JsonParser : IParser
    {
        public string JsonData { get; private set; }

        public SchoolData SchoolData { get; private set; }

        public JsonParser(string jsonData)
        {
            this.JsonData = jsonData;
        }

        public virtual void ParseFullJson()
        {
            SchoolData = JsonConvert.DeserializeObject<SchoolData>(JsonData);
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
