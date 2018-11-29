using UnityEngine;
using System;

public abstract class Singleton<T> : IDisposable where T : class, new()
{
    protected static T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }

    /// <summary>
    /// 实现的接口 --- Dispose表示将当前资源关闭
    /// </summary>
    public virtual void Dispose()
    {

    }
}