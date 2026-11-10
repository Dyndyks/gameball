using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class randomtext : MonoBehaviour
{
    public string[] words;
    public AccelerationConrtolScrept aclerscrept;
    public Text mesagetext;
    public Button buttonstart;
    private int count;

    public void RandomText() //функция срабатывает при нажатии на кнопку
    {
        
        mesagetext.text = null;
        aclerscrept.enabled = false; //отключаем скрипт чтобы пользователь не ломал программу
        buttonstart.enabled = false; //также поступаем с кнопкой
        aclerscrept.count = 0;
        StartCoroutine(GeneratText());
        StartCoroutine(Thetimecycletext());
        

    }

    IEnumerator GeneratText() //данная функция дает рандомное слово из списка
    {
        yield return new WaitForSeconds(0.3f);
        mesagetext.text = words[Random.Range(0, words.Length)];
    }

    IEnumerator Thetimecycletext() //данная функция добавляет прозрачность тексту
    {
        
        for (int i = 0; i != 255; i += 5)
        {
            if (i < 30)
            {
                yield return new WaitForSeconds(0.1f);
            }
            mesagetext.color = new Color32(255, 255, 255, (byte)i);
            yield return new WaitForSeconds(0.01f);
        }
        aclerscrept.enabled = true;
        buttonstart.enabled = true;
    }
}
