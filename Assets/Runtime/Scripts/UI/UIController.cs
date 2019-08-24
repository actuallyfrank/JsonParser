using Assets.Runtime.Scripts.JsonParser;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Tooltip("The area where the user data will be displayed.")]
    public Text UserDataText;

    [Tooltip("The area where the subject data will be displayed.")]
    public Text SubjectDataText;

    [Tooltip("The area where the classes data will be displayed")]
    public Text ClassesDataText;

    [Tooltip("The JSON file that will be parsed.")]
    public TextAsset SchoolDataJson;

    void Start()
    {
        if (!UserDataText) Debug.LogError(nameof(UserDataText) + " has not been set.");

        ClearData();
        StartCoroutine(ParseOverTimeWithTeacherParser());
    }

    private IEnumerator ParseOverTimeWithTeacherParser()
    {
        TeacherParser parser = new TeacherParser(SchoolDataJson.text);
        parser.ParseFullJson();

        foreach (var item in parser.SchoolData.userdata)
        {
            UserDataText.text += item + "\n";
            yield return new WaitForSeconds(0.5f);
        }

        foreach (var item in parser.SchoolData.subjects)
        {
            SubjectDataText.text += item + "\n";
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator ParseOverTimeWithStudentParser()
    {
        StudentParser parser = new StudentParser(SchoolDataJson.text);
        parser.ParseFullJson();

        foreach (var item in parser.SchoolData.userdata)
        {
            UserDataText.text += item + "\n";
            yield return new WaitForSeconds(0.5f);
        }

        foreach (var item in parser.SchoolData.classes)
        {
            ClassesDataText.text += item + "\n";
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void ClearData()
    {
        UserDataText.text = "";
        SubjectDataText.text = "";
        ClassesDataText.text = "";
    }
}
