using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherManager : MonoBehaviour
{
    ChageWeatherImage changeWeatherImage;
    public Sprite[] icons;
    public float WeatherStatus;
    public float Temperature;
    private void TodayWeather()
    {
        WeatherStatus = Random.Range(0, 3);
        ///0ÀÌ¸é ¸¼À½
        ///1ÀÌ¸é Èê¸²
        ///2ÀÌ¸é ´«³»¸²
    }
    private void TodayTemperature()
    {
        Temperature = Random.Range(-10f, 10f);
    }

    
    void Start()
    {
        changeWeatherImage = GetComponent<ChageWeatherImage>();
        StartCoroutine(ChangeWeather());
    }
    
    IEnumerator ChangeWeather()
    {
        while(true)
        {
            TodayWeather();
            TodayTemperature();
            Debug.Log("³¯¾¾°¡ ¹Ù²î¾ú½À´Ï´Ù.");
            changeWeatherImage.ChangeIcon();

            yield return new WaitForSeconds(5f);
        }
    }

}
