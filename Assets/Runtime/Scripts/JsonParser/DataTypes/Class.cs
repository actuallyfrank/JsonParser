using System.Collections.Generic;

namespace Assets.Runtime.Scripts.JsonParser
{
    public class Class
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<int> subjects { get; set; }

        public override string ToString()
        {
            string text = $"Name: {name} subjects: ";
            foreach (var subject in subjects)
            {
                text += $"{subject}, ";
            }
            return text;
        }
    }
}
