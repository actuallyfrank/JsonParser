using System.Collections.Generic;
using Assets.Runtime.Scripts.JsonParser.DataTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assets.Runtime.Scripts.JsonParser
{
    public class SchoolParser : IParser
    {
        public string JsonData { get; private set; }

        public SchoolData SchoolData { get; private set; }

        public SchoolParser(string jsonData)
        {
            this.JsonData = jsonData;
            this.SchoolData = new SchoolData();
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
