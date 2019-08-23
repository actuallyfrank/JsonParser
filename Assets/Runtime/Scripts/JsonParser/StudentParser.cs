using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Runtime.Scripts.JsonParser
{
    public class StudentParser : JsonParser
    {
        public List<Userdata> userData { get; private set; }
        public List<Class> classesData { get; private set; }

        public StudentParser(string jsonData) : base(jsonData)
        {
        }

        public override void Parse()
        {
            JObject data = JObject.Parse(jsonData);
            IList<JToken> userDataResults = data["userdata"].Children().ToList();
            IList<JToken> classesDataResults = data["classes"].Children().ToList();

            userData = ConvertJTokensToList<Userdata>(userDataResults);
            classesData = ConvertJTokensToList<Class>(classesDataResults);
        }
    }
}
