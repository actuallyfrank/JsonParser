using System.Collections.Generic;

namespace Assets.Runtime.Scripts.JsonParser
{
    public class Userdata
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public int birthday { get; set; }
        public List<int> subjects { get; set; }
        public int @class { get; set; }

        public override string ToString()
        {
            return $"Name: {name}, Surname: {surname}, Gender: {gender}, Birthday: {birthday}";
        }
    }
}
