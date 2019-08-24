using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace Assets.Runtime.Scripts.JsonParser
{
    public class TeacherParser : JsonParser
    {
        public List<Userdata> userData { get; private set; }
        public List<Subject> subjectData { get; private set; }
        public TeacherParser(string jsonData) : base(jsonData)
        {

        }

        public override void ParseFullJson()
        {     
            JObject data = JObject.Parse(JsonData);
            IList<JToken> userDataResults = data["userdata"].Children().ToList();
            IList<JToken> subjectsResults = data["subjects"].Children().ToList();

            userData = ConvertJTokensToList<Userdata>(userDataResults);
            subjectData = ConvertJTokensToList<Subject>(subjectsResults);
        }
    }
}
