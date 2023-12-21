using System.Collections;
using UnityEngine;


public class WeatherManager : MonoBehaviour
{
    ChangeWeatherImage changeWeatherImage;
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
        changeWeatherImage = GetComponent<ChangeWeatherImage>();
        StartCoroutine(ChangeWeather());
    }
    
    IEnumerator ChangeWeather()
    {
        while(true)
        {
            TodayWeather();
            TodayTemperature();
            Debug.Log("³¯¾¾°¡ ¹Ù²î¾ú½À´Ï´Ù.");
            yield return new WaitForSeconds(0.01f);
            changeWeatherImage.ChangeIcon();

            yield return new WaitForSeconds(20f);
        }
    }

}
