using Assets.Runtime.Scripts.JsonParser.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Runtime.Scripts.StructureModifier
{
    public interface IStructureModifier
    {
        string GenerateData(SchoolData schoolData);
    }
}
