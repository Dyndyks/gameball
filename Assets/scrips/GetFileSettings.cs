using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class GetFileSettings : MonoBehaviour
{
    public JsonSettings json_settings;
    public string path_file_my;
    public JsonSettings Get_File() //метод получени€ файла
    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR
        path_file_my = Path.Combine(Application.streamingAssetsPath, "settings.json");
#endif
#if UNITY_ANDROID
        path_file_my = Path.Combine(Application.persistentDataPath, "settings.json");
#endif
        if (!File.Exists(path_file_my))
        {
            StartCoroutine(Read_File_WWW());
        }
        else
        {
            json_settings = JsonUtility.FromJson<JsonSettings>(File.ReadAllText(path_file_my));
        }
        
        return json_settings;
    }

    public IEnumerator Read_File_WWW() //чтобы прочитать созданный файл на андроид после компил€ции 
    {
        string path = Path.Combine(Application.streamingAssetsPath, "settings.json");
        string dataJSON;
        UnityWebRequest www = UnityWebRequest.Get(path);
        yield return www.SendWebRequest();
        dataJSON = www.downloadHandler.text;
        json_settings = JsonUtility.FromJson<JsonSettings>(dataJSON);
    }

    [Serializable]
    public class JsonSettings //класс дл€ значений файла json
    {
        public bool accelerometer_bool;
    }
}
