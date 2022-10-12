using UnityEngine;
using System.IO;
public class _10_12_Recursive : MonoBehaviour
{
    string path;
    void Start()
    {
        path = Application.dataPath + "/";        
        if (Directory.Exists(path))
        {
            // This path is a directory
            ProcessDirectory(path);
        }        
    }
    public static void ProcessDirectory(string targetDirectory)
    {
        //���丮 �ȿ� �ִ� ��� ������ �ֺܼ信 ���
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        foreach (string fileName in fileEntries)
        {
            Debug.Log(fileName);
        }
        //���丮 �ȿ� �ִ� ��� ���� ���丮�� �ֺܼ信 ���
        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach (string subdirectory in subdirectoryEntries)
        {
            Debug.Log(subdirectory);  
            ProcessDirectory(subdirectory);
        }              
    }   
    void Update()
    {
        
    }
}
