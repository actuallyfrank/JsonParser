﻿using Assets.Runtime.Scripts.JsonParser;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class StudentParserTests
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
        public void ParseUserData()
        {
            StudentParser studentParser = new StudentParser(schoolJsonData);

            studentParser.ParseJson();

            Userdata first = studentParser.SchoolData.userdata[0];
            Assert.AreEqual("Roy", first.name);
            Assert.AreEqual("van Borkel", first.surname);
            Assert.AreEqual("MALE", first.gender);
            Assert.AreEqual(713863410, first.birthday);

            Userdata last = studentParser.SchoolData.userdata[studentParser.SchoolData.userdata.Count - 1];
            Assert.AreEqual("Cirilla", last.name);
            Assert.AreEqual("Riannon", last.surname);
            Assert.AreEqual("FEMALE", last.gender);
            Assert.AreEqual(383180400, last.birthday);
        }

        [Test]
        public void ParseClassData()
        {
            StudentParser studentParser = new StudentParser(schoolJsonData);

            studentParser.ParseJson();

            Class first = studentParser.SchoolData.classes[0];
            Assert.AreEqual(1, first.id);
            Assert.AreEqual("Class A", first.name);
            Assert.AreEqual(1, first.subjects[0]);
            Assert.AreEqual(2, first.subjects[1]);

            Class last = studentParser.SchoolData.classes[studentParser.SchoolData.classes.Count - 1];
            Assert.AreEqual(5, last.id);
            Assert.AreEqual("Class E", last.name);
            Assert.AreEqual(1, last.subjects[0]);
            Assert.AreEqual(2, last.subjects[1]);
            Assert.AreEqual(4, last.subjects[2]);
        }
    }
}
