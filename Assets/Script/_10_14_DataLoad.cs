using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class _10_14_DataLoad : MonoBehaviour
{
    void Start()
    {
        //TextAsset textAsset = Resources.Load<TextAsset>("Building_1");
        string path = Application.dataPath + "/" + "Building_1.csv";
        DataLoad(path);

        //문자열 관련 함수
        string data = "Cube_1_1";
        //Cube라는 부분문자열을 다른 변수에 저장
        int stringPos = data.IndexOf("_");
        //처음 등장한 _ 위치를 찾음
        string subData = data.Substring(0, stringPos);
        Debug.Log("부분문자열 = "+ subData);

        //data에서 "_"를 "#"으로 변경하려면?
        string newData = data.Replace("_", "#");
        Debug.Log("새로운 문자열 = " + newData);

        //문자열에서 앞뒤의 공백문자를 제거하려면
        string testData = "Data_1  ";
        Debug.Log(testData);
        newData = testData.Trim();
        Debug.Log(newData);
    }
    public void DataLoad(string _fullPath)
    {
        string line = string.Empty;
        using(StreamReader sr = new StreamReader(_fullPath))
        {
            sr.ReadLine();
            while((line = sr.ReadLine()) != null)
            {
                Debug.Log(line);
                string [] datas = line.Split(",");
                int objIndex = int.Parse(datas[0]);
                string objName = datas[1];
                int parIndex = int.Parse(datas[2]);
                float xPos = float.Parse(datas[3]);
                float yPos = float.Parse(datas[4]);
                float zPos = float.Parse(datas[5]);
                Vector3 objPos = new Vector3(xPos, yPos, zPos);
            }
            sr.Close();
        }
    }
    void Update()
    {
        
    }
}
