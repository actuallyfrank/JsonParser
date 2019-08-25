using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Assets.Runtime.Scripts.JsonParser;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class JsonReader
    {
        private string schoolJsonData;

        [SetUp]
        public void Setup()
        {
            schoolJsonData = Resources.Load<TextAsset>("SchoolData").text;
        }

        [Test]
        public void SchoolDataIsNotNull()
        {
            SchoolParser jsonParser = new SchoolParser(schoolJsonData);
            jsonParser.ParseJson();

            Assert.IsNotNull(jsonParser.SchoolData);
        }

        [Test]
        public void ContainsRightAmountOfSchoolData()
        {
            SchoolParser jsonParser = new SchoolParser(schoolJsonData);
            jsonParser.ParseJson();

            Assert.AreEqual(5, jsonParser.SchoolData.classes.Count);
            Assert.AreEqual(20, jsonParser.SchoolData.userdata.Count);
            Assert.AreEqual(4, jsonParser.SchoolData.subjects.Count);
        }
    }
}
