using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton design pattern which inherits Monobehaviour
/// </summary>
/// <typeparam name="T"></typeparam>
public partial class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool _ShuttingDown = false;
    private static object _Lock = new object();
    private static T _Instance;
    public static T Instance
    {
        get
        {
            if (_ShuttingDown)
            {
                Debug.Log("[Singleton] Instance '" + typeof(T) + "' already destroyed. Returning null.");
                return null;
            }
            lock (_Lock) //Thread Safe
            {
                if (_Instance == null)
                {
                    _Instance = (T)FindObjectOfType(typeof(T));
                  
                    if (_Instance == null)
                    {
                        var singletonObject = new GameObject();
                        _Instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString();
                    }
                }
                return _Instance;
            }
        }
    }

    protected virtual void Awake()
    {
        _ShuttingDown = false;
    }

    private void OnApplicationQuit()
    {
        _ShuttingDown = true;
    }
    private void OnDestroy()
    {
        _ShuttingDown = true;
    }
}