using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Std
{
    public class In
    {
        public static int[] ReadInts(string fileName)
        {
            var textAsset = Resources.Load<TextAsset>(fileName);
            var textStr = textAsset.text;
            var intTexts = textStr.Split();
            List<int> ints = new List<int>();
            int intRead = 0;
            foreach (var intText in intTexts)
            {
                if (int.TryParse(intText, out intRead))
                {
                    ints.Add(intRead);
                }
            }

            return ints.ToArray();
        }

    }

}
