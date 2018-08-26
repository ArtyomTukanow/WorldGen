using UnityEngine;

namespace WorldGen.Utils
{
    public class SavingData
    {
        public static void LocalSave(string key, string data)
        {
            PlayerPrefs.SetString(key,data);
            PlayerPrefs.Save();
        }
        public static void LocalSave(string key, float data)
        {
            PlayerPrefs.SetFloat(key,data);
            PlayerPrefs.Save();
        }
        public static void LocalSave(string key, int data)
        {
            PlayerPrefs.SetInt(key,data);
            PlayerPrefs.Save();
        }

        public static string LocalLoadString(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public static float LocalLoadFloat(string key)
        {
            return PlayerPrefs.GetFloat(key);
        }

        public static int LocalLoadInt(string key)
        {
            return PlayerPrefs.GetInt(key);
        }
    }
}