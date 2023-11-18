using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                if (results.Length == 0)
                {
                    Debug.LogError("SingletonScriptableObject -> Instance -> results length is 0 for type " + typeof(T).ToString() + ".");
                }
                if(results.Length > 1)
                {
                    Debug.LogError("SingletonScriptableObejct -> Instance -> results length is greater then 1 for type " + typeof(T).ToString() + ",");
                }
                _instance = results[0];
            }
            return _instance;
        }
    }
}
