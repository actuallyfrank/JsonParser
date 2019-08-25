using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Runtime.Scripts.JsonParser;
using Assets.Runtime.Scripts.JsonParser.DataTypes;

namespace Assets.Runtime.Scripts.StructureModifier
{
    public class ClassOverview : IStructureModifier
    {
        public string GenerateData(SchoolData schoolData)
        {
            string total = String.Empty;

            foreach (var item in schoolData.classes)
            {
                total += $"{item.name}:";
                total += $"subjects: ";

                foreach (var subject in SubjectsByClassId(schoolData, item.id))
                {
                    total += $"{ subject.name}, ";
                }

                total += $"users: ";
                foreach (var user in UsersByClassId(schoolData, item.id))
                {
                    total += $"{user.GenderPrefix()}{user.surname}, {user.name}; \n ";
                }
            }

            return total;
        }

        private List<Userdata> UsersByClassId(SchoolData schoolData, int classId)
        {
            List<Userdata> userData = new List<Userdata>();
            foreach (var user in schoolData.userdata)
            {
                if (user.@class == classId)
                    userData.Add(user);
            }
            userData = userData.OrderBy(u => u.surname).ToList();
            return userData;
        }

        private List<Subject> SubjectsByClassId(SchoolData schoolData, int classId)
        {
            List<Subject> subjects = new List<Subject>();
            Class schoolClass = schoolData.classes.Where(c => c.id == classId).Single();
            if (schoolClass == null)
                return subjects;

            foreach (var subject in schoolClass.subjects)
            {
                Subject newSubject = SubjectById(schoolData, subject);
                if (newSubject != null)
                    subjects.Add(newSubject);
            }
            return subjects;
        }

        private Subject SubjectById(SchoolData schoolData, int subjectId)
        {
            return schoolData.subjects.Where(s => s.id == subjectId).Single();
        }
    }
}
