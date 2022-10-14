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

        //���ڿ� ���� �Լ�
        string data = "Cube_1_1";
        //Cube��� �κй��ڿ��� �ٸ� ������ ����
        int stringPos = data.IndexOf("_");
        //ó�� ������ _ ��ġ�� ã��
        string subData = data.Substring(0, stringPos);
        Debug.Log("�κй��ڿ� = "+ subData);

        //data���� "_"�� "#"���� �����Ϸ���?
        string newData = data.Replace("_", "#");
        Debug.Log("���ο� ���ڿ� = " + newData);

        //���ڿ����� �յ��� ���鹮�ڸ� �����Ϸ���
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
