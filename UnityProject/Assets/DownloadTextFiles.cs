using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadTextFiles : MonoBehaviour
{

    void Start()
    {

        List<string> urls = new List<string>
        {
            "https://algs4.cs.princeton.edu/14analysis/1Kints.txt",
            "https://algs4.cs.princeton.edu/14analysis/2Kints.txt",
            "https://algs4.cs.princeton.edu/14analysis/4Kints.txt",
            "https://algs4.cs.princeton.edu/14analysis/8Kints.txt",
            "https://algs4.cs.princeton.edu/14analysis/16Kints.txt",
            "https://algs4.cs.princeton.edu/14analysis/32Kints.txt",
            "https://algs4.cs.princeton.edu/14analysis/1Mints.txt",
        };

        foreach (var url in urls)
        {

            var lastIndexOfSep = url.LastIndexOf("/");
            var fileName = url.Substring(lastIndexOfSep + 1);
            var filePath = Application.dataPath + "/Resources/" + fileName;

            StartCoroutine(GetText(url, filePath));
        }

        Debug.Log("download completed");
    }

    IEnumerator GetText(string url, string savePath)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            var dirPath = Path.GetDirectoryName(savePath);
            Directory.CreateDirectory(dirPath);
            File.WriteAllText(savePath, www.downloadHandler.text);
            Debug.LogFormat("download from {0} to {1}",url,savePath);
        }
    }
}
