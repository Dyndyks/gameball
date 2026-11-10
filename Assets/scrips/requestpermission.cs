using UnityEngine;
using AndroidRuntimePermissionsNamespace;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Linq;

public class requestpermission : MonoBehaviour
{
    static public bool is_get_permission;
    public Button settings_button;
    string[] params_set = {"android.permission.READ_EXTERNAL_STORAGE", "android.permission.WRITE_EXTERNAL_STORAGE"};

    private void Start()
    {
        if (AndroidRuntimePermissions.CheckPermissions(params_set).All(bool_param => bool_param == true))
        {
            is_get_permission = true;
        }
        else
        {
            is_get_permission = false;
        }

        if (is_get_permission)
        {
            settings_button.enabled = true;
        }
        else
        {
            settings_button.enabled = false;
        }
    }
    public void Click_But()  //при нажатие на копку срабатывает запрос
    {
        RequestPermission();
    }
    async void RequestPermission()  //запрос на разрешение чтения и записи
    {
        AndroidRuntimePermissions.Permission[] result = await AndroidRuntimePermissions.RequestPermissionsAsync(params_set);
        if (result[0] == AndroidRuntimePermissions.Permission.Granted && result[1] == AndroidRuntimePermissions.Permission.Granted)
        {
            is_get_permission = true;
            settings_button.enabled = true;
        }
        else
        {
            is_get_permission = false;
            settings_button.enabled = false;
        }
    }
}