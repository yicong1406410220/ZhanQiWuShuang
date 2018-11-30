using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{

    public DataManager()
    {
        Debug.Log("你好");
    }

    public Dictionary<string, Dictionary<string, string>> CSV_nni = new Dictionary<string, Dictionary<string, string>>();


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
        string Text = textAsset.text;
        string[] Textrows = Text.Split('\n');
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

        for (int i = 0; i < Textrows.Length; i++)
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();            
            for (int j = 1; j < Textcolname.Length -1; j++)
            {
                //Dic.Add(Textcolname[1], )
            }

            Dic.Clear();
        }



    }


}
