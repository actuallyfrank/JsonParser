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
    public class TeacherParser : SchoolParser
    {
        public TeacherParser(string jsonData) : base(jsonData)
        {

        }

        public override void ParseJson()
        {     
            JObject data = JObject.Parse(JsonData);

            // Only parse the relevat datas
            IList<JToken> userDataResults = data["userdata"].Children().ToList();
            IList<JToken> subjectsResults = data["subjects"].Children().ToList();

            SchoolData.userdata = ConvertJTokensToList<Userdata>(userDataResults);
            SchoolData.subjects = ConvertJTokensToList<Subject>(subjectsResults);
        }
    }
}
