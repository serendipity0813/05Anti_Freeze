using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChageWeatherImage : MonoBehaviour
{
    WeatherManager weatherManager;
    public void ChangeIcon()
    {
        switch (weatherManager.WeatherStatus)
        {
            case 0:
                GameObject.Find("Weather_Image").GetComponent<Image>().sprite = weatherManager.icons[0];
                break;
            case 1:
                GameObject.Find("Weather_Image").GetComponent<Image>().sprite = weatherManager.icons[1];
                break;
            case 2:
                GameObject.Find("Weather_Image").GetComponent<Image>().sprite = weatherManager.icons[2];
                break;
        }
    }
    
}
