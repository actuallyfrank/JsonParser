using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Assets.Runtime.Scripts.JsonParser;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
            Assert.IsNotNull(schoolJsonData);
        }

        [Test]
        public void ReadWithStandardJsonParser()
        {
            JsonParser jsonParser = new JsonParser(schoolJsonData);
            jsonParser.Parse();
        }
    }
}
