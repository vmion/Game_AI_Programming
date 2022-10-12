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
        //디렉토리 안에 있는 모든 파일을 콘솔뷰에 출력
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        foreach (string fileName in fileEntries)
        {
            Debug.Log(fileName);
        }
        //디렉토리 안에 있는 모든 하위 디렉토리를 콘솔뷰에 출력
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
