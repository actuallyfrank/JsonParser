using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Runtime.Scripts.JsonParser.DataTypes
{
    public class SchoolData
    {
        public List<Subject> subjects { get; set; }
        public List<Class> classes { get; set; }
        public List<Userdata> userdata { get; set; }
    }
}
