using UnityEngine;

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;
   public static T Instance 
   {
        get 
        {
            if (_instance == null)
            {
                T[] result = Resources.FindObjectsOfTypeAll<T>();
                if (result.Length == 0)
                {
                    Debug.LogError("SingletonScriptableObject -> Instance -> results length is 0 for type " +typeof(T).ToString());
                    return null;
                }
                else if (result.Length > 1)
                {
                    Debug.LogError("SingletonScriptableObject -> Instance -> results length is greater than 1 for type " +typeof(T).ToString());
                    return null;
                }
                _instance = result[0];
            }
            return _instance;
        }
   }
}
