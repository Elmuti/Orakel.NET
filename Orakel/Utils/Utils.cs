﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLua;

namespace Orakel
{
    public static class Utils
    {
        public static float Tick
        {
            get
            {
                float ms = (float)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds);
                return ms / 1000f;
            }
        }

        public static string GetTypeName(object obj)
        {
            return obj.GetType().Name;
        }

        public static bool ObjectIsA(object obj, string className)
        {
            if (GetTypeName(obj) == className)
                return true;

            return false;
        }

        internal static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        internal static StreamReader GenerateStreamFromString(string s)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(s);
            MemoryStream stream = new MemoryStream(byteArray);
            StreamReader reader = new StreamReader(stream);
            return reader;
        }

        internal static class MergeSort
        {
            static private void MainMerge(int[] numbers, int left, int mid, int right)
            {
                int[] temp = new int[25];
                int i, eol, num, pos;

                eol = (mid - 1);
                pos = left;
                num = (right - left + 1);

                while ((left <= eol) && (mid <= right))
                {
                    if (numbers[left] <= numbers[mid])
                        temp[pos++] = numbers[left++];
                    else
                        temp[pos++] = numbers[mid++];
                }

                while (left <= eol)
                    temp[pos++] = numbers[left++];

                while (mid <= right)
                    temp[pos++] = numbers[mid++];

                for (i = 0; i < num; i++)
                {
                    numbers[right] = temp[right];
                    right--;
                }
            }

            static public void SortMerge(int[] numbers, int left, int right)
            {
                int mid;

                if (right > left)
                {
                    mid = (right + left) / 2;
                    SortMerge(numbers, left, mid);
                    SortMerge(numbers, (mid + 1), right);

                    MainMerge(numbers, left, (mid + 1), right);
                }
            }
        }
    }
}
