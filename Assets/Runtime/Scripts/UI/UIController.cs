using Assets.Runtime.Scripts.JsonParser;
using Assets.Runtime.Scripts.JsonParser.DataTypes;
using Assets.Runtime.Scripts.Save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public enum ParseType
    {
        Default,
        Teacher,
        Student
    }

    [Tooltip("The area where the user data will be displayed.")]
    public Text UserDataText;

    [Tooltip("The area where the subject data will be displayed.")]
    public Text SubjectDataText;

    [Tooltip("The area where the classes data will be displayed.")]
    public Text ClassesDataText;

    [Tooltip("The are where the name of the current parser will be displayed.")]
    public Text CurrentParserText;

    [Tooltip("The JSON file that will be parsed.")]
    public TextAsset SchoolDataJson;

    [Tooltip("The time it will take before every individual element is processed.")][Range(0, 3f)]
    public float ProcessingTime = 1f;

    public ParseType CurrentParseType { get; private set; } = ParseType.Teacher;
    public SchoolParser CurrentParser { get; private set; }

    void Start()
    {
        if (!UserDataText) Debug.LogError(nameof(UserDataText) + " has not been set.");

        SwitchParser();
    }

    public void SwitchParser()
    {
        ClearData();

        CurrentParser = InitializeParser(SelectNextParser(CurrentParseType));
        CurrentParser.ParseJson();

        StopAllCoroutines();
        StartCoroutine(ProcessSchoolDataToUIWithInterval(CurrentParser.SchoolData, ProcessingTime));

        CurrentParserText.text = "Parser type: " + CurrentParseType.ToString();
    }

    public void PrintDataToLocation()
    {
        SchoolParser parser = new SchoolParser(SchoolDataJson.text);
        parser.ParseJson();
        SaveFile.SaveSchoolDataToUsersLocation(parser.SchoolData);
    }

    private ParseType SelectNextParser(ParseType current)
    {
        ParseType next = current.Next();
        CurrentParseType = next;
        return next;
    }

    private SchoolParser InitializeParser(ParseType parseType)
    {
        SchoolParser parser;
        switch (parseType)
        {
            default:
                parser = new SchoolParser(SchoolDataJson.text);
                break;
            case ParseType.Student:
                parser = new StudentParser(SchoolDataJson.text);
                break;
            case ParseType.Teacher:
                parser = new TeacherParser(SchoolDataJson.text);
                break;
        }
        return parser;
    }

    private IEnumerator ProcessSchoolDataToUIWithInterval(SchoolData schoolData, float interval)
    {
        yield return StartCoroutine(ProcessDataToUIWithInterval(schoolData.subjects, SubjectDataText, interval));
        yield return StartCoroutine(ProcessDataToUIWithInterval(schoolData.classes, ClassesDataText, interval));
        yield return StartCoroutine(ProcessDataToUIWithInterval(schoolData.userdata, UserDataText, interval));
    }

    private IEnumerator ProcessDataToUIWithInterval<T>(List<T> userData, Text targetTextArea, float interval)
    {
        if (userData == null) yield break;
        foreach (var data in userData)
        {
            targetTextArea.text += data + "\n";
            targetTextArea.text += "-----------------------------------------\n";
            yield return new WaitForSeconds(interval);
        }
    }

    private void ClearData()
    {
        UserDataText.text = "";
        SubjectDataText.text = "";
        ClassesDataText.text = "";
    }
}
