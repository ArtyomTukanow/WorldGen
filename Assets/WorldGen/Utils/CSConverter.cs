using System;
using UnityEngine;

namespace WorldGen.Utils
{
    public class CSConverter
    {
        /// <summary>
        /// Конвертирует полярную в декартову систему координат
        /// </summary>
        /// <param name="r">длина</param>
        /// <param name="f">градус</param>
        /// <returns>возвращает координаты точки (x,y) в декартовой системе</returns>
        public static Vector2 ToCartesian(float r, float f)
        {
            return new Vector2(r*Convert.ToSingle(Math.Cos(f)), r*Convert.ToSingle(Math.Sin(f)));
        }
    }
}