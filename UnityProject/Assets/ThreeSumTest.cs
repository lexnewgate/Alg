using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeSumTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        List<string> testfiles = new List<string>
        {
            "1Kints",
            "2Kints",
            "4Kints",
            // "8Kints"
        };

        foreach (var testfile in testfiles)
        {
            int[] ints;
            using (var timer = new CustomTimer("readint"))
            {
                ints = Std.In.ReadInts(testfile);    
            }

            using (var timer = new CustomTimer("ThreeSum", 1))
            {
                Debug.LogFormat("result: {0}", Count(ints));
            }
        }
    }


    int Count(int[] a)
    {
        int n = a.Length;
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    if (a[i] + a[j] + a[k] == 0)
                    {
                        cnt++;
                    }
                }
            }
        }

        return cnt;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
