using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class _10_11_MenuExample
{
    //MapData/Export�� �޴��� �����ϸ� MapExport�Լ��� ȣ���
    [MenuItem("MapData/Export/Test")]
    static public void MapExport()
    {
        
        Debug.Log("Export");
        //�θ� �ε����� ������ ��ųʸ� ����
        Dictionary<GameObject, int> exportdic = new Dictionary<GameObject, int>();

        //���Ӿ��� ������ "Monster"��� �±׸� ���� ���� ������Ʈ�� �˻��Ͽ�
        //���Ͽ� �̸��� ��ǥ������ ����
        GameObject[] findObjs = GameObject.FindGameObjectsWithTag("Building");
        string selectedFile = EditorUtility.SaveFilePanel("SaveFile", Application.dataPath, "None", "csv");
        //�޴��� Ŭ���� ������ �����ϰ� �����͸� �����Ѵ�.
        //Application.dataPath�� Assets���� ������ ��θ� �ǹ�
        
        //System.Array.Sort(findObjs);
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
            int parentIndex = -1;
            sr.WriteLine("Index, Name, Pr.Index, PosX, PosY, PosZ, RotX, RotY, RotZ, ScaleX, ScaleY, ScaleZ");
            //�����̸��� �ؿ� ���а����� �����ش�.
            for (int i = 0; i < findObjs.Length; i++)
            {
                sr.Write((i + 1).ToString());
                sr.Write(",");
                sr.Write(findObjs[i].name);
                sr.Write(",");
                if (findObjs[i].transform.parent.name.Equals("Building"))
                {
                    parentIndex = 0;
                }
                else
                {
                    //�θ��ε����� �˻�
                    /*
                    foreach(KeyValuePair<GameObject,int> one in exprotlist)
                    {
                        if(one.Key.name.Equals(findObjs[i].transform.parent.name))
                        {
                            parentIndex = one.Value;
                            break;
                        }
                    }
                    */
                    parentIndex = exportdic[findObjs[i].transform.parent.gameObject];
                }
                sr.Write(parentIndex.ToString());
                Debug.Log(parentIndex.ToString());
                sr.Write(",");
                sr.Write(findObjs[i].transform.localPosition.x);
                sr.Write(",");
                sr.Write(findObjs[i].transform.localPosition.y);
                sr.Write(",");
                sr.Write(findObjs[i].transform.localPosition.z);
                sr.Write("\n");
                //��ųʸ��� ����
                exportdic.Add(findObjs[i], i+1);
            }
            sr.Close();
        }        
    }
}
