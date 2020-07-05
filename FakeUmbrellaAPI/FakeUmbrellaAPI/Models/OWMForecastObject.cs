﻿/// <summary>
/// Class auto-generated based on JSON from Open Weather Map
/// </summary>

public class OWMForecastObject
{
    public string cod { get; set; }
    public int message { get; set; }
    public int cnt { get; set; }
    public List[] list { get; set; }
    public City city { get; set; }
}

public class City
{
    public Coord coord { get; set; }
    public int timezone { get; set; }
    public int sunrise { get; set; }
    public int sunset { get; set; }
}

public class Coord
{
}

public class List
{
    public int dt { get; set; }
    public Main main { get; set; }
    public Weather[] weather { get; set; }
    public Clouds clouds { get; set; }
    public Wind wind { get; set; }
    public Sys sys { get; set; }
    public string dt_txt { get; set; }
    public Rain rain { get; set; }
}

public class Main
{
    public float temp { get; set; }
    public float feels_like { get; set; }
    public float temp_min { get; set; }
    public float temp_max { get; set; }
    public int pressure { get; set; }
    public int sea_level { get; set; }
    public int grnd_level { get; set; }
    public int humidity { get; set; }
    public float temp_kf { get; set; }
}

public class Clouds
{
    public int all { get; set; }
}

public class Wind
{
    public float speed { get; set; }
    public int deg { get; set; }
}

public class Sys
{
    public string pod { get; set; }
}

public class Rain
{
    public float _3h { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}
