using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSettingsScript : MonoBehaviour
{
    public GetFileSettings getfilesettings;
    public Button Save_Button;
    public Button Exit_button;
    public Toggle IsAccelerometerToggle;
    int count;
    float positinon_x;



    private void Start() //берем данные из файла для чтения; данные применяем к кнопке
    {
        getfilesettings.json_settings = getfilesettings.Get_File(); //используем метод для получения файла
        positinon_x = Exit_button.transform.position.x;
        IsAccelerometerToggle.isOn = getfilesettings.json_settings.accelerometer_bool;
        count = 0;

    }

    private void FixedUpdate()  //проверяем если пользователь нажал на кнопку делаем активную кнопку
    {
        if (count != 0)
        {
            if (Exit_button.transform.position.x == positinon_x)
            {
                Exit_button.transform.Translate(Vector3.right * 1.3f);
            }
            Save_Button.gameObject.SetActive(true);
        }
    }

    public void Bool_Toggle(bool value)  //булевое возращение кнопки
    {
        count++;
        getfilesettings.json_settings.accelerometer_bool = value;
    }

    public void Save_Config() //сохраняем измененные данные и выходим
    {
        count = 0;
        File.WriteAllText(getfilesettings.path_file_my, JsonUtility.ToJson(getfilesettings.json_settings));
        Save_Button.gameObject.SetActive(false);
        SceneManager.LoadScene("MAIN");

    }
}
