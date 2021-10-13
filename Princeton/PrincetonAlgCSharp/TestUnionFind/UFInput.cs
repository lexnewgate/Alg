using System;
using System.Collections.Generic;
using System.IO;

namespace TestUnionFind
{
    public class UFInput
    {
        public enum InputType 
        {
           Tiny,
           Medium,
           Large
        }

        static string GetInputFileName(InputType inputType)
        {
            string inputFileName = string.Empty;
            
            switch (inputType)
            {
                case InputType.Tiny:
                    inputFileName = "tinyUF.txt";
                    break;
                case InputType.Medium:
                    inputFileName = "mediumUF.txt";
                    break;
                case InputType.Large:
                    inputFileName = "largeUF.txt";
                    break;
            }

            return inputFileName;
        }

        public class InputInfo
        {
            public int nodeCount;
            public List<(int p, int q)> connectedPairs=new List<(int p, int q)>();
        }

        public static InputInfo GetPairs(InputType inputType)
        {
            InputInfo inputInfo = new InputInfo();
            string fileName = GetInputFileName(inputType);
            using (var reader=new StreamReader(File.OpenRead(fileName)))
            {
                int nodeCount=int.Parse(reader.ReadLine()) ;
                inputInfo.nodeCount = nodeCount;
                var line = reader.ReadLine();
                while(!string.IsNullOrEmpty(line))
                {
                    var pqStrs = line.Split();
                    int p = int.Parse(pqStrs[0]);
                    int q = int.Parse(pqStrs[1]);
                    inputInfo.connectedPairs.Add((p,q));
                    line = reader.ReadLine();
                }
            }

            return inputInfo;
        }
    }
}