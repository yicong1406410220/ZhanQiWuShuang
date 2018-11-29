using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// 解析csv的类型
/// </summary>
public class CsvHelper
{
    /// <summary>
    /// 字符串是否包含奇数个引号
    /// </summary>
    /// <param name="str">相关字符串</param>
    /// <returns></returns>
    private static bool _isOddDoubleQuota(string str)
    {
        return _getDoubleQuotaCount(str) % 2 == 1;
    }

    private static int _getDoubleQuotaCount(string str)
    {
        string[] strArray = str.Split('"');
        int doubleQuotaCount = strArray.Length - 1;
        doubleQuotaCount = doubleQuotaCount < 0 ? 0 : doubleQuotaCount;
        return doubleQuotaCount;
    }

    /**
     * csv的每一行的每一项的引号个数必定为偶数
　　　* 生成的Dictionary<string,List<string>>以每一列的第一行元素作为key,其它元素的集合作为value
     */
    public static Dictionary<string, List<string>> AnalysisCsvByStr(string csvInfo)
    {
        //首行的每列数据项作为字典的Key
        Dictionary<string, List<string>> csvInfoDic = new Dictionary<string, List<string>>();
        Regex regex = new Regex(@"\r\n");
        string[] infoLines = regex.Split(csvInfo);
        List<string>[] itemListArray = new List<string>[0];
        for (int i = 0, length = infoLines.Length; i < length; i++)
        {
            if (string.IsNullOrEmpty(infoLines[i]))
            {
                continue;
            }
            string[] lineInfoArray = infoLines[i].Split(',');
            List<string> rowItemList = new List<string>();
            string strTemp = string.Empty;
            for (int j = 0; j < lineInfoArray.Length; j++)
            {
                strTemp += lineInfoArray[j];
                if (_isOddDoubleQuota(strTemp))
                {
                    if (j != lineInfoArray.Length - 1)
                    {
                        strTemp += ",";
                    }
                }
                else
                {
                    if (strTemp.StartsWith("\"") && strTemp.EndsWith("\""))
                    {
                        strTemp = strTemp.Substring(1, strTemp.Length - 2);
                    }
                    rowItemList.Add(strTemp);
                    strTemp = string.Empty;
                }
            }
            if (i == 0)
            {
                itemListArray = new List<string>[rowItemList.Count];
                for (int temp = 0; temp < itemListArray.Length; temp++)
                {
                    itemListArray[temp] = new List<string>();
                }
            }
            int indexTemp = 0;
            for (; indexTemp < rowItemList.Count; indexTemp++)
            {
                if (indexTemp == itemListArray.Length)
                {
                    throw new ArgumentException("csv文件有误");
                }
                itemListArray[indexTemp].Add(rowItemList[indexTemp]);
            }
            if (indexTemp < itemListArray.Length - 1)
            {
                throw new ArgumentException("csv文件有误");
            }
        }
        for (int i = 0; i < itemListArray.Length; i++)
        {
            string key = itemListArray[i][0];
            //去除第一个元素，其它元素集合作为value
            itemListArray[i].RemoveAt(0);
            csvInfoDic.Add(key, itemListArray[i]);
        }
        return csvInfoDic;
    }

    public static Dictionary<string, List<string>> AnalysisCsvByFile(string csvPath)
    {
        if (File.Exists(csvPath))
        {
            string csvInfo = File.ReadAllText(csvPath, Encoding.UTF8);
            return AnalysisCsvByStr(csvInfo);
        }
        else
        {
            throw new FileNotFoundException("未找到文件：" + csvPath);
        }
    }
}
