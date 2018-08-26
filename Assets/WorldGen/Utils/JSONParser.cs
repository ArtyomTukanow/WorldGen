
using System;
using UnityEngine;

namespace WorldGen.Utils
{
    public class JSONParser
    {
        public static string encode(object obj)
        {
            return JsonUtility.ToJson(obj);
        }

//        public static object decode(string json, Type type)
//        {
//            return JsonUtility.FromJson<type>(json);
//        }
    }
}