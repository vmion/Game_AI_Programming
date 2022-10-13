using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class _10_11_MenuExample
{
    //MapData/Export의 메뉴를 선택하면 MapExport함수가 호출됨
    [MenuItem("MapData/Export/Test")]
    static public void MapExport()
    {
        
        Debug.Log("Export");
        //부모 인덱스를 저장할 딕셔너리 생성
        Dictionary<GameObject, int> exportdic = new Dictionary<GameObject, int>();

        //게임씬에 생성된 "Monster"라는 태그를 갖는 게임 오브젝트를 검색하여
        //파일에 이름을 쉼표단위로 저장
        GameObject[] findObjs = GameObject.FindGameObjectsWithTag("Building");
        string selectedFile = EditorUtility.SaveFilePanel("SaveFile", Application.dataPath, "None", "csv");
        //메뉴를 클릭시 파일을 생성하고 데이터를 저장한다.
        //Application.dataPath는 Assets폴더 까지의 경로를 의미
        
        //System.Array.Sort(findObjs);
        //Reverse를 통해 배열을 내림차순 정리해준 후 파일에 작성하도록 만들어 깔끔하게 유지한다.

        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/" + "test.csv"))
        {
            //cvs파일의 첫줄(컬럼)에 표기성분 값을 Split을 이용하여 적어준다.
            /*
            string indexCVS = "Name, PositionX, PositionY, PositionZ ";
            string[] indexCVSsplit = indexCVS.Split(",");
            sr.Write(indexCVS);
            sr.Write("\n");
            */
            int parentIndex = -1;
            sr.WriteLine("Index, Name, Pr.Index, PosX, PosY, PosZ, RotX, RotY, RotZ, ScaleX, ScaleY, ScaleZ");
            //성분이름들 밑에 성분값들을 적어준다.
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
                    //부모인덱스를 검색
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
                //딕셔너리에 저장
                exportdic.Add(findObjs[i], i+1);
            }
            sr.Close();
        }        
    }
}
