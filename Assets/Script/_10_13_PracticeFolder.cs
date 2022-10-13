using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class _10_13_PracticeFolder : MonoBehaviour
{
    string path;
    void Start()
    {
        path = Application.dataPath + "/";
        MakeFolder(path);
    }
    
    public static void MakeFolder(string targetDirectory)
    {
        Debug.Log("Folder");
        
        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/" + "Folder.txt"))
        {
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach(string subdirectory in subdirectoryEntries)
            {
                ProcessFolder(Application.dataPath + "/", sr);
                sr.Close();
            }            
        }
    }
    public static void ProcessFolder(string targetDirectory, StreamWriter _sr)
    {
        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach (string subdirectory in subdirectoryEntries)
        {            
            Debug.Log(subdirectory);
            _sr.WriteLine(subdirectory);
            ProcessFolder(subdirectory, _sr);
        }
    }
    void Update()
    {
        
    }
}
