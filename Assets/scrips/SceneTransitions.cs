using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitions : MonoBehaviour
{
    public void ButtonClick(string name)
    {
        SceneManager.LoadScene(name);
    }
}
