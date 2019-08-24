using Assets.Runtime.Scripts.JsonParser;
using Assets.Runtime.Scripts.JsonParser.DataTypes;
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

        TeacherParser parser = new TeacherParser(SchoolDataJson.text);
        parser.ParseFullJson();

        StartCoroutine(ProcessSchoolDataToUIWithInterval(parser.SchoolData, 0.2f));
    }

    private IEnumerator ProcessSchoolDataToUIWithInterval(SchoolData schoolData, float interval)
    {
        yield return StartCoroutine(ProcessDataToUIWithInterval(schoolData.userdata, UserDataText, interval));
        yield return StartCoroutine(ProcessDataToUIWithInterval(schoolData.subjects, SubjectDataText, interval));
        yield return StartCoroutine(ProcessDataToUIWithInterval(schoolData.classes, ClassesDataText, interval));
    }

    private IEnumerator ProcessDataToUIWithInterval<T>(List<T> userData, Text targetTextArea, float interval)
    {
        foreach (var data in userData)
        {
            targetTextArea.text += data + "\n";
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
