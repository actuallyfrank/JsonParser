using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    private static JsonReader instance;
    public static JsonReader Instance()
    {
        if (!instance)
        {
            GameObject JsonReader = new GameObject("[ JsonReader ]");
            instance = JsonReader.AddComponent<JsonReader>();
        }
        return instance;
    }

}
