using Assets.Runtime.Scripts.JsonParser.DataTypes;
using Assets.Runtime.Scripts.ModifiedStructures;
using SFB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Runtime.Scripts.Save
{
    public class SaveFile
    {
        public static void SaveSchoolDataToUsersLocation(SchoolData schoolData)
        {
            var path = StandaloneFileBrowser.SaveFilePanel("Save File", "", "", "txt");

            IStructureModifier modifiedStructure = new ClassOverview();

            File.WriteAllText(path, modifiedStructure.GenerateData(schoolData));           
        }
    }
}
