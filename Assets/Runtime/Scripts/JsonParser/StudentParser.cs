using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Runtime.Scripts.JsonParser
{
    public class StudentParser : SchoolParser
    {

        public StudentParser(string jsonData) : base(jsonData)
        {
        }

        public override void ParseJson()
        {
            JObject data = JObject.Parse(JsonData);
            IList<JToken> userDataResults = data["userdata"].Children().ToList();
            IList<JToken> classesDataResults = data["classes"].Children().ToList();

            SchoolData.userdata = ConvertJTokensToList<Userdata>(userDataResults);
            SchoolData.classes = ConvertJTokensToList<Class>(classesDataResults);
        }
    }
}
