using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class _10_7_FileIO : MonoBehaviour
{
    void Start()
    {
        string path = Application.dataPath + "/" + "Hello.txt";
        WriteString(path);
        ReadString(path);
    }
    public void WriteString(string _fullPath)
    {
        using(StreamWriter sr = new StreamWriter(_fullPath))
        {
            sr.Write("안녕하세요");
            sr.Write("\n");
            sr.Write("Hello");
            sr.Write("\n");
            sr.Write("니하오");
            sr.Close();
        }
    }
    public void ReadString(string _fullPath)
    {
        using(StreamReader sr = new StreamReader(_fullPath))
        {
            string stringData = string.Empty;
            while((stringData = sr.ReadLine()) != null)
            {
                Debug.Log("읽은데이터 = " + stringData);
            }
            sr.Close();
        }
    }
    void Update()
    {
        
    }
}
