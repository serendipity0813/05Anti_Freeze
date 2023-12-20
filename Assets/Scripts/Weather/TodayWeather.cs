using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherManager : MonoBehaviour
{
    public float WeatherStatus;
    public float Temperature;
    public Image WeatherIcon;
    private void TodayWeather()
    {
        WeatherStatus = Random.Range(0, 3);
        ///0¿Ã∏È ∏º¿Ω
        ///1¿Ã∏È »Í∏≤
        ///2¿Ã∏È ¥´≥ª∏≤
    }
    private void TodayTemperature()
    {
        Temperature = Random.Range(-10f, 10f);
    }
    void Start()
    {
        StartCoroutine(ChangeWeather());
    }

    IEnumerator ChangeWeather()
    {
        TodayWeather();
        TodayTemperature();
        yield return new WaitForSeconds(500f);
        ChangeWeather();
    }

}
