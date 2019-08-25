using Assets.Runtime.Scripts.JsonParser.DataTypes;
using Assets.Runtime.Scripts.StructureModifier;
using SFB;
using System.IO;

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
