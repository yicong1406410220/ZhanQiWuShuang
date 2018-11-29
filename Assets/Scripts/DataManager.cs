using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{

    public DataManager()
    {
        
    }



    public void SaveDBKey(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public void SaveDBKey(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public void SaveDBKey(string key, string value)
    {
        PlayerPrefs.GetString(key, value);
    }

    public float GetDBKey(string key, float value)
    {
        return PlayerPrefs.GetFloat(key, value);
    }

    public int GetDBKey(string key, int value)
    {
        return PlayerPrefs.GetInt(key, value);
    }

    public string GetDBKey(string key, string value)
    {
        return PlayerPrefs.GetString(key, value);
    }


}
