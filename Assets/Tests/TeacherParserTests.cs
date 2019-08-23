﻿using System.Collections;
using System.Collections.Generic;
using Assets.Runtime.Scripts.JsonParser;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TeacherParserTests
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
        public void ParseSubjectData()
        {
            TeacherParser teacherParser = new TeacherParser(schoolJsonData);

            teacherParser.Parse();

            Subject first = teacherParser.subjectData[0];
            Assert.AreEqual(1, first.id);
            Assert.AreEqual("Chemistry", first.name);
            Assert.AreEqual("Chem.", first.@short);

            Subject last = teacherParser.subjectData[teacherParser.subjectData.Count - 1];
            Assert.AreEqual(4, last.id);
            Assert.AreEqual("Language", last.name);
            Assert.AreEqual("Lang.", last.@short);
        }

        [Test]
        public void ParseUserData()
        {
            TeacherParser teacherParser = new TeacherParser(schoolJsonData);

            teacherParser.Parse();

            Userdata first = teacherParser.userData[0];
            Assert.AreEqual("Roy", first.name);
            Assert.AreEqual("van Borkel", first.surname);
            Assert.AreEqual("MALE", first.gender);
            Assert.AreEqual(713863410, first.birthday);

            Userdata last = teacherParser.userData[teacherParser.userData.Count - 1];
            Assert.AreEqual("Cirilla", last.name);
            Assert.AreEqual("Riannon", last.surname);
            Assert.AreEqual("FEMALE", last.gender);
            Assert.AreEqual(383180400, last.birthday);

        }
    }
}