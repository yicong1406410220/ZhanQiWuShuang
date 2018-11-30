using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{

    public DataManager()
    {
        Debug.Log("你好");
        ParsingCSV(CSV_nii, "nii");
    }

    public Dictionary<string, Dictionary<string, string>> CSV_nii = new Dictionary<string, Dictionary<string, string>>();


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

    public void ParsingCSV(Dictionary<string, Dictionary<string,string>> DDC, string path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Data/csv/" + path);
        string TextAll = textAsset.text;
        TextAll = TextAll.Remove(TextAll.LastIndexOf("\r\n"), 1);
        string[] Textrows = TextAll.Split(new string[] { "\r\n" }, StringSplitOptions.None);
        string[] Textcolname = Textrows[1].Split(',');
        string[,] TextRCS = new string[Textrows.Length, Textcolname.Length];
        for (int i = 0; i < Textrows.Length; i++)
        {
            string[] Textcols = Textrows[i].Split(',');
            for (int j = 0; j < Textcolname.Length; j++)
            {
                TextRCS[i, j] = Textcols[j];
            }
        }

        for (int i = 2; i < Textrows.Length; i++)
        {         
            for (int j = 1; j < Textcolname.Length -1; j++)
            {
                SetDDC(TextRCS[i, 0], Textcolname[j], TextRCS[i, j], DDC);
            }
        }
    }

    /// <summary>
    /// 赋值
    /// </summary>
    public void SetDDC(string key1, string key2, string value, Dictionary<string, Dictionary<string, string>> mDict1)
    {
        if (mDict1.ContainsKey(key1))
        {
            var dict2 = mDict1[key1];
            if (dict2.ContainsKey(key2))
            {
                //dict2[key2] = value;
                Debug.LogError("重复赋值：" + dict2[key2]);
            }
            else
            {
                dict2.Add(key2, value);
            }

        }
        else
        {
            var dict2 = new Dictionary<string, string>();
            dict2.Add(key2, value);
            mDict1.Add(key1, dict2);
        }
    }

}
