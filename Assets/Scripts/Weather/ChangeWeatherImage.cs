using UnityEngine;
using UnityEngine.UI;

public class ChangeWeatherImage : MonoBehaviour
{
    WeatherManager weatherManager;
    public GameObject weatherImageObj;
    public Image weatherImage;

    public void Start()
    {
        weatherManager = GetComponent<WeatherManager>();
        weatherImageObj = GameObject.FindGameObjectWithTag("WeatherIcon");
        weatherImage = weatherImageObj.GetComponent<Image>();
    }
    public void ChangeIcon()
    {
        switch (weatherManager.WeatherStatus)
        {
            case 0:
                weatherImage.sprite = weatherManager.icons[0];
                Debug.Log("¸¼À½");
                break;
            case 1:
                weatherImage.sprite = weatherManager.icons[1];
                Debug.Log("Èå¸²");
                break;
            case 2:
                weatherImage.sprite = weatherManager.icons[2];
                Debug.Log("´«");
                break;
        }
    }
    
}
