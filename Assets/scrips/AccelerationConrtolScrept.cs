using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class AccelerationConrtolScrept : MonoBehaviour
{
    public GameObject ball;
    public randomtext pntext;
    private Vector3 startballposition;
    private Vector3 acceleron;
    private Vector3 movingupanddown = Vector3.up * 10;
    public int count;


    private void Start() //метод дл€ получени€ начальной позиции объекта шар
    {
        startballposition = ball.transform.position;
    }

    private void FixedUpdate()
    {
        
        acceleron = Input.acceleration; //получаем акселерометр

        if (acceleron.sqrMagnitude >= 5f) //выполн€етс€ только если тр€сем экран
        {

            AcceBallMove();
            count++;

            if (count == 16) //чтобы текст не по€вл€лс€ через одну тр€ску, объ€вл€ем count
            {
                pntext.RandomText(); //метод другого скрипта
            }
        }

        else
        {
            count = 0;
            ball.transform.position = startballposition;
        }

    }

    private void AcceBallMove() //метод дл€ движени€ шара вверх вниз
    {
        

        ball.transform.Translate(movingupanddown * 3 * Time.deltaTime);

        if (ball.transform.position.y > startballposition.y)
        {
            movingupanddown = Vector3.down * 10;
        }

        if (ball.transform.position.y < startballposition.y)
        {
            movingupanddown = Vector3.up * 10;
        }

    }
}
