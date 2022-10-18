using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace WebPrefasSpace
{
    public static class WebPrefs
    {

        public static void DeleteKey(string key)
        {
#if UNITY_WEBGL
        RemoveFromLocalStorage(key: key);
#else
          
#endif
        }

        public static bool HasKey(string key)
        {

#if UNITY_WEBGL
            try
            {
                return (HasKeyInLocalStorage(key) == 1);
            }
            catch
            {
                return false;
            }
#else
                       return false;
#endif
        }

        public static string GetString(string key)
        {

#if UNITY_WEBGL
        return LoadFromLocalStorage(key: key);
#else
            return (UnityEngine.PlayerPrefs.GetString(key: key));
#endif
        }

        public static void SetString(string key, string value)
        {
#if UNITY_WEBGL
        SaveToLocalStorage(key: key, value: value);
#else
            UnityEngine.PlayerPrefs.SetString(key: key, value: value);
#endif

        }

        public static void Save()
        {

#if !UNITY_WEBGL
            UnityEngine.PlayerPrefs.Save();
#endif
        }

#if UNITY_WEBGL
      [DllImport("__Internal")]
      private static extern void SaveToLocalStorage(string key, string value);

      [DllImport("__Internal")]
      private static extern string LoadFromLocalStorage(string key);

      [DllImport("__Internal")]
      private static extern void RemoveFromLocalStorage(string key);

      [DllImport("__Internal")]
      private static extern int HasKeyInLocalStorage(string key);
#endif
    }
}