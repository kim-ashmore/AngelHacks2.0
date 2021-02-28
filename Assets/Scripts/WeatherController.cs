using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Net;
using System.IO;
using UnityEngine.Networking;
//using Assets;

public class WeatherController : MonoBehaviour
{

    private const string API_KEY = "bc52e875536b34a5ee651c9729b6f18a";
    public string CityId;
    public GameObject SnowSystem;

    private const float API_CHECK_MAXTIME = 10 * 60.0f; //10 minutes
    private float apiCheckCountdown = API_CHECK_MAXTIME;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetWeather(CheckSnowStatus));
    }

    // Update is called once per frame
    void Update()
    {
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            apiCheckCountdown = API_CHECK_MAXTIME;
            StartCoroutine(GetWeather(CheckSnowStatus));
        }
    }

    IEnumerator GetWeather(Action<WeatherInfo> onSuccess)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}", CityId, API_KEY)))
        {
            yield return req.Send(); //the point where the method will be resumed from the next frame
            while (!req.isDone) //makes sure that the response arrived before continuing with any other action
                yield return null;
            byte[] result = req.downloadHandler.data;
            string weatherJSON = System.Text.Encoding.Default.GetString(result);
            WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(weatherJSON);
            onSuccess(info); //onSuccess lambda which will further process the data
        }
    }
     
    public void CheckSnowStatus(WeatherInfo weatherObj)
    {
        bool snowing = weatherObj.weather[0].main.Equals("Snow");
        Debug.Log(weatherObj.weather[0].main);
        if (snowing)
            SnowSystem.SetActive(true);
        else
            SnowSystem.SetActive(false);
    }
}

[Serializable] // to deserialize the JSON response into them
public class Weather
{
    public int id;
    public string main;
}

[Serializable]
public class WeatherInfo
{
    public int id;
    public string name;
    public List<Weather> weather;
}
