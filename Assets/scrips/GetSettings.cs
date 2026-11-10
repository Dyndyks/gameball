using UnityEngine;
using UnityEngine.UI;

public class GetSettings : MonoBehaviour
{
    public GetFileSettings getfilesettings;
    public Button play_button;
    public GameObject acellerationcontrol;
    private void Start() //получаем и применяем настройки
    {
        if (requestpermission.is_get_permission)
        {
            getfilesettings.json_settings = getfilesettings.Get_File();
            if (getfilesettings.json_settings.accelerometer_bool)
            {
                play_button.gameObject.SetActive(false);
                acellerationcontrol.gameObject.SetActive(true);
            }
            else
            {
                play_button.gameObject.SetActive(true);
                acellerationcontrol.gameObject.SetActive(false);

            }
        }
        
    }

}
