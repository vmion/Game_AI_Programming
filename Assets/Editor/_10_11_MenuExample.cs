using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class _10_11_MenuExample
{
    //MapData/Export�� �޴��� �����ϸ� MapExport�Լ��� ȣ���
    [MenuItem("MapData/Export")]
    static public void MapExport()
    {
        Debug.Log("Export");
        //���Ӿ��� ������ "Monster"��� �±׸� ���� ���� ������Ʈ�� �˻��Ͽ�
        //���Ͽ� �̸��� ��ǥ������ ����
        GameObject[] findObjs = GameObject.FindGameObjectsWithTag("Monster");
        //string selectedFile = EditorUtility.SaveFilePanel("SaveFile", Application.dataPath, "None", "csv");
        //�޴��� Ŭ���� ������ �����ϰ� �����͸� �����Ѵ�.
        //Application.dataPath�� Assets���� ������ ��θ� �ǹ�
        
        System.Array.Reverse(findObjs);
        //Reverse�� ���� �迭�� �������� �������� �� ���Ͽ� �ۼ��ϵ��� ����� ����ϰ� �����Ѵ�.

        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/" + "test.csv"))
        {
            //cvs������ ù��(�÷�)�� ǥ�⼺�� ���� Split�� �̿��Ͽ� �����ش�.
            /*
            string indexCVS = "Name, PositionX, PositionY, PositionZ ";
            string[] indexCVSsplit = indexCVS.Split(",");
            sr.Write(indexCVS);
            sr.Write("\n");
            */
            sr.WriteLine("Name, PositionX, PositionY, PositionZ");
            //�����̸��� �ؿ� ���а����� �����ش�.
            for (int i = 0; i < findObjs.Length; i++)
            {                
                sr.Write(findObjs[i].name);
                sr.Write(",");
                sr.Write(findObjs[i].transform.position.x);
                sr.Write(",");
                sr.Write(findObjs[i].transform.position.y);
                sr.Write(",");
                sr.Write(findObjs[i].transform.position.z);
                sr.Write("\n");               
            }
            sr.Close();
        }        
    }
}
